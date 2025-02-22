using RabbitMQ.Client;

namespace SensorDataService.Infrastructure.Messaging.Interfaces;

public interface IRabbitMqConnection
{
    Task<IConnection> GetConnectionAsync(); 
    Task<IChannel> CreateChannelAsync();
}