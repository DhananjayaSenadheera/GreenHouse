using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SensorDataService.Domain.Interfaces;
using SensorDataService.Infrastructure.Configurations;
using SensorDataService.Infrastructure.Repositories;

namespace SensorDataService.Infrastructure.DependencyInjection;

public static class InfDependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IGreenHouseRepository, GreenHouseRepository>();
        services.AddDbContext<SensorDataServiceDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}