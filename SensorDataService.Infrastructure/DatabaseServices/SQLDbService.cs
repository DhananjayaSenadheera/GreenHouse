using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SensorDataService.Infrastructure.Configurations;

namespace SensorDataService.Infrastructure.DatabaseServices;

public static class SQLDbService
{
    public static IServiceCollection DatabaseService(this IServiceCollection service,IConfiguration configuration)
    {
        service.AddDbContext<SensorDataServiceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return service;
    }
}