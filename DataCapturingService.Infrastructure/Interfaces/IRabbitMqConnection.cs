using RabbitMQ.Client;

namespace DataCapturingService.Infrastructure.Interfaces;

public interface IRabbitMqConnection
{
    Task<IConnection> GetConnectionAsync(); 
    Task<IChannel> CreateChannelAsync();
}