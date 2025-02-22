using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataStorageService.Domain.Interfaces;
using DataStorageService.Infrastructure.Messaging;
using DataStorageService.Infrastructure.Messaging.Connections;
using DataStorageService.Infrastructure.Messaging.Interfaces;
using DataStorageService.Infrastructure.Repositories;
using DataStorageService.Infrastructure.Configurations;
using DataStorageService.Infrastructure.DatabaseServices;


namespace DataStorageService.Infrastructure.DependencyInjection;

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
        services.AddHostedService<RabbitMqConsumer>();
        return services;
    }
}