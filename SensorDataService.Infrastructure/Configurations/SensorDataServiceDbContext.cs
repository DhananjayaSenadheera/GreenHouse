using Microsoft.EntityFrameworkCore;
using SensorDataService.Domain.Entities;

namespace SensorDataService.Infrastructure.Configurations;

public class SensorDataServiceDbContext : DbContext
{
   public SensorDataServiceDbContext(DbContextOptions<SensorDataServiceDbContext> options) : base(options){}
   public DbSet<Sensor> Sensors { get; set; }
   public DbSet<Greenhouse> Greenhouses { get; set; }
   public DbSet<SensorReading> SensorReadings { get; set; }
}