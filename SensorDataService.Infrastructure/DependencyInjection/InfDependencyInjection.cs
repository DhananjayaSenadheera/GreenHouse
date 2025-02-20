using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SensorDataService.Domain.Interfaces;
using SensorDataService.Infrastructure.Configurations;
using SensorDataService.Infrastructure.DatabaseServices;
using SensorDataService.Infrastructure.Interfaces;
using SensorDataService.Infrastructure.Repositories;
using SensorDataService.Infrastructure.Services;

namespace SensorDataService.Infrastructure.DependencyInjection;

public static class InfDependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IGreenHouseRepository, GreenHouseRepository>();
        services.AddScoped<ISensorsRepository, SensorRepository>();
        services.AddScoped<ISensorReadingsRepository, SensorReadingsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
        services.AddScoped<IDefaultSettingRepository, DefaultSettingRepository>();
        services.DatabaseService(configuration);
        services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();
        services.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();
        return services;
    }
}