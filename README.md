# GreenHouse — Cloud-Based Greenhouse Monitoring & Automated Irrigation

A .NET 9 microservices backend for monitoring greenhouse conditions and driving automated
irrigation. IoT sensors push readings into the system, readings are queued and persisted
asynchronously, and the analysis service exposes them for dashboards and irrigation decisions.

Built as the backend for my MSc Computer Science dissertation at York St John University:
*Greenhouse Resource Optimization and Automated Irrigation System using Azure Cloud and
.NET Core Microservices*.

The React front end that consumes these APIs lives in
[GreenHouseFrontend](https://github.com/DhananjayaSenadheera/GreenHouseFrontend).

---

## Architecture

Six independently deployable services. Each follows Clean Architecture with four projects —
`*.API`, `*.Application`, `*.Domain`, `*.Infrastructure` — so that domain logic has no
dependency on the web or persistence layers.

```
                    ┌──────────────────────┐
  IoT sensors  ───► │ DataCapturingService │  POST /api/DataCapturing
                    └──────────┬───────────┘
                               │ publishes
                               ▼
                    ┌──────────────────────┐
                    │ RabbitMQ             │  queue: Sensor_Readings_Queue
                    └──────────┬───────────┘  (durable, persistent messages)
                               │ consumes
                               ▼
                    ┌──────────────────────┐
                    │ DataStorageService   │ ───► SQL Server (GreenHouseDB)
                    └──────────┬───────────┘
                               │ reads
                               ▼
   Dashboard  ◄──── ┌──────────────────────┐
                    │ DataAnalysingService │
                    └──────────────────────┘

   ┌───────────────────────┐  ┌──────────────────────┐  ┌───────────────┐
   │ AuthenticationService │  │ AccessControlService │  │ EmailService  │
   │ JWT issue / profile   │  │ user & role admin    │  │ SMTP alerts   │
   └───────────────────────┘  └──────────────────────┘  └───────────────┘
```

### Services

| Service | Responsibility |
|---|---|
| **DataCapturingService** | Ingests sensor readings over REST and publishes them to RabbitMQ. Write path is fire-and-forget so sensor devices are never blocked by database latency. |
| **DataStorageService** | `BackgroundService` consumer that reads `Sensor_Readings_Queue`, deserialises each reading and persists it via EF Core. Also exposes CRUD APIs for greenhouses, sensors and readings. Messages are acknowledged only after a successful write. |
| **DataAnalysingService** | Read-side API over stored readings — per-greenhouse and per-sensor queries that feed the dashboard and irrigation logic. |
| **AuthenticationService** | Registration, login, profile and account deletion. Issues JWT bearer tokens; passwords hashed with BCrypt. |
| **AccessControlService** | User and role administration behind the authenticated boundary. |
| **EmailService** | SMTP notification sending for alerts and account email. |

### Design decisions

- **Asynchronous ingestion.** Sensors write to a queue rather than straight to the database.
  A storage outage delays persistence but never drops readings or blocks a device.
- **CQRS via MediatR.** Every operation is a `Command` or `Query` with its own handler, so
  the read and write paths evolve independently.
- **Validation at the boundary.** FluentValidation validators run in a MediatR
  `ValidationBehavior` pipeline, keeping controllers thin.
- **Separate auth database.** `AuthenticationDB` is isolated from `GreenHouseDB` so
  credentials are not co-located with operational data.

---

## Tech stack

- **.NET 9** / ASP.NET Core
- **Entity Framework Core 9** with SQL Server
- **RabbitMQ** (`RabbitMQ.Client` 7, MassTransit)
- **MediatR 12** — CQRS command/query dispatch
- **FluentValidation** — request validation pipeline
- **AutoMapper** / **Riok.Mapperly** — entity ↔ DTO mapping
- **JWT Bearer authentication**, **BCrypt.Net** password hashing
- **Swashbuckle / Swagger** — API documentation

---

## Running locally

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or `mcr.microsoft.com/mssql/server` in Docker)
- RabbitMQ with the management plugin

Start the infrastructure:

```bash
docker run -d --name greenhouse-sql \
  -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<your-password>" \
  -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest

docker run -d --name greenhouse-rabbit \
  -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

### Configuration

Each `*.API` project reads its settings from `appsettings.json`. Do not commit real values —
set them with [user secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets)
instead:

```bash
cd AuthenticationService.API
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=AuthenticationDB;User Id=sa;Password=<your-password>;TrustServerCertificate=True;"
dotnet user-secrets set "Jwt:Key" "<a-32-character-random-secret>"
```

| Setting | Used by | Purpose |
|---|---|---|
| `ConnectionStrings:DefaultConnection` | Auth, DataStorage, DataAnalysing, AccessControl | SQL Server connection |
| `Jwt:Key` / `Jwt:Issuer` / `Jwt:Audience` | AuthenticationService | Token signing and validation |
| `RabbitMq:HostName` | DataCapturing, DataStorage | Message broker host |
| SMTP settings | EmailService | Outbound mail |

### Build and run

```bash
git clone https://github.com/DhananjayaSenadheera/GreenHouse.git
cd GreenHouse
dotnet restore GreenhouseData.sln
dotnet build GreenhouseData.sln

# apply migrations
dotnet ef database update --project AuthenticationService.Infrastructure  --startup-project AuthenticationService.API
dotnet ef database update --project DataStorageService.Infrastructure     --startup-project DataStorageService.API

# run services (separate terminals)
dotnet run --project AuthenticationService.API   # https://localhost:7004
dotnet run --project DataStorageService.API      # https://localhost:7078
dotnet run --project DataCapturingService.API
dotnet run --project DataAnalysingService.API
dotnet run --project AccessControlService.API
dotnet run --project EmailService.API
```

Swagger UI is available at `/swagger` on each running service.

---

## API overview

**AuthenticationService** — `/api/auth`

| Method | Route | Description |
|---|---|---|
| `POST` | `/register` | Create an account |
| `POST` | `/login` | Authenticate, returns a JWT |
| `GET` | `/profile` | Current user profile *(auth required)* |
| `PUT` | `/Edit` | Update profile *(auth required)* |
| `DELETE` | `/Delete` | Delete account *(auth required)* |

**DataCapturingService** — `/api/DataCapturing`

| Method | Route | Description |
|---|---|---|
| `POST` | `/` | Submit a batch of sensor readings for queuing |

```json
{
  "dataList": [
    { "sensor_Code": "TEMP-01", "value": 24.6, "readingDate": "2025-06-01T08:00:00Z" }
  ]
}
```

**DataStorageService** and **DataAnalysingService** expose CRUD and query endpoints for
`GreenHouse`, `Sensor` and `SensorReadings`. See Swagger for the full contract.

Protected endpoints expect an `Authorization: Bearer <token>` header.

---

## Project status

Active development happens on the `Development` branch. Known gaps and next steps:

- Containerise each service and add a `docker-compose.yml` for one-command local startup
- Add unit and integration test projects
- Add a retry / dead-letter policy for messages that fail to persist
- Consolidate configuration into a shared settings library

---

## Author

**Dhananjaya Senadheera** — Software Engineer (Cloud & .NET)
[LinkedIn](https://www.linkedin.com/in/dhananjaya-senadheera/) · [GitHub](https://github.com/DhananjayaSenadheera)
