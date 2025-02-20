using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;

namespace SensorDataService.Infrastructure.Interfaces;

public interface IRabbitMqConnection
{
    Task<IConnection> GetConnectionAsync(); 
    Task<IChannel> CreateChannelAsync();
}