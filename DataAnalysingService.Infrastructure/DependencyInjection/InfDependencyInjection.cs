using DataAnalysingService.Domain.Interfaces;
using DataAnalysingService.Infrastructure.DatabaseServices;
using DataAnalysingService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAnalysingService.Infrastructure.DependencyInjection;

public static class InfDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>) ,typeof(GenericRepository<>));
        services.AddScoped<IGreenHouseRepository, GreenHouseRepository>();
        services.AddScoped<ISensorsRepository, SensorRepository>();
        services.AddScoped<ISensorReadingsRepository, SensorReadingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
        services.DatabaseService(configuration);
        return services;
    }
}