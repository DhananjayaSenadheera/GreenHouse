using DataCapturingService.Domain.Interfaces;
using DataCapturingService.Infrastructure.Messaging;
using DataCapturingService.Infrastructure.Messaging.Connections;
using DataCapturingService.Infrastructure.Messaging.Interfaces;
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