using DataCapturingService.Domain.Interfaces;
using DataCapturingService.Infrastructure.Configurations;
using DataCapturingService.Infrastructure.Interfaces;
using DataCapturingService.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataCapturingService.Infrastructure.DependencyInjection;

public static class InfDependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();
        services.AddSingleton<IRabbitMqProducer, RabbitMqProducer>();
        return services;
    }
}