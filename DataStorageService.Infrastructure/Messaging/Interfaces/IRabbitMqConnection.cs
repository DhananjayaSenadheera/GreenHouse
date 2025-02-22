using RabbitMQ.Client;

namespace DataStorageService.Infrastructure.Messaging.Interfaces;

public interface IRabbitMqConnection
{
    Task<IConnection> GetConnectionAsync(); 
    Task<IChannel> CreateChannelAsync();
}