using DataStorageService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataStorageService.Infrastructure.DatabaseServices;

public static class SQLDbService
{
    public static IServiceCollection DatabaseService(this IServiceCollection service,IConfiguration configuration)
    {
        service.AddDbContext<SensorDataServiceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return service;
    }
}