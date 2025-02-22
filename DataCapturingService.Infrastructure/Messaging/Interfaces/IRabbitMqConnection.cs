using RabbitMQ.Client;

namespace DataCapturingService.Infrastructure.Messaging.Interfaces;

public interface IRabbitMqConnection
{
    Task<IConnection> GetConnectionAsync(); 
    Task<IChannel> CreateChannelAsync();
}