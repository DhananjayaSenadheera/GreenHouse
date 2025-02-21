using DataCapturingService.Infrastructure.Interfaces;
using RabbitMQ.Client;

namespace DataCapturingService.Infrastructure.Configurations;

public class RabbitMqConnection :  IRabbitMqConnection ,IDisposable
{
    private IConnection? _connection;
    private readonly ConnectionFactory _factory;
    private readonly object _lock = new(); 
    public RabbitMqConnection()
    {
        _factory = new ConnectionFactory()
        {
            HostName = "localhost",  
            AutomaticRecoveryEnabled = true, 
            NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
        };

        Task.Run(() => InitializeConnection()).Wait();
    }

    private async Task InitializeConnection()
    {
        lock (_lock) 
        {
            if (_connection == null || !_connection.IsOpen)
            {
                try
                {
                    _connection = _factory.CreateConnectionAsync().GetAwaiter().GetResult();
                    Console.WriteLine("RabbitMQ persistent connection established.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"RabbitMQ connection failed: {ex.Message}. Retrying...");
                }
            }
        }
    }

    public async Task<IConnection> GetConnectionAsync()
    {
        if (_connection == null || !_connection.IsOpen)
        {
            Console.WriteLine("RabbitMQ connection lost. Reconnecting...");
            await InitializeConnection();
        }
        return _connection ?? throw new InvalidOperationException("RabbitMQ connection could not be established.");
    }

    public async Task<IChannel> CreateChannelAsync()
    {
        var connection = await GetConnectionAsync();
        return await connection.CreateChannelAsync();
    }

    public void Dispose()
    {
        _connection?.Dispose();
        Console.WriteLine("RabbitMQ connection closed.");
    }
}