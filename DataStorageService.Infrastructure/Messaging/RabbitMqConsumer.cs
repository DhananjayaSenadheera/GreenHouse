using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using DataStorageService.Application.Requests.SensorReadings.Commands.Create;
using DataStorageService.Application.Requests.SensorReadings.DTos;
using DataStorageService.Domain.Entities;
using DataStorageService.Infrastructure.Messaging.Interfaces;

namespace DataStorageService.Infrastructure.Messaging;

public class RabbitMqConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private IConnection _connection;
    private IChannel _channel;
    private readonly IRabbitMqConnection _rabbitMqConnection;

    public RabbitMqConsumer(IServiceProvider serviceProvider, IRabbitMqConnection rabbitMqConnection)
    {
        _serviceProvider = serviceProvider;
        _rabbitMqConnection = rabbitMqConnection;
        
        
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _channel = await _rabbitMqConnection.CreateChannelAsync();
            await _channel.QueueDeclareAsync(
                queue: "Sensor_Readings_Queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken
            );
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                try
                {
                    var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var sensorData = JsonSerializer.Deserialize<SensorReadingCreateDTo>(message);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        await mediator.Send(new SensorReadingCreateCommand
                        {
                            DataList = new List<SensorReadingCreateDTo> { sensorData }
                        });
                    }

                    await _channel.BasicAckAsync(ea.DeliveryTag, false, stoppingToken);
                    Console.WriteLine($"Processed Sensor Data: {sensorData.Sensor_Code}, Value: {sensorData.Value}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing message: " + ex.Message);
                    throw;
                }
            };
            await _channel.BasicConsumeAsync(
                queue: "Sensor_Readings_Queue",
                autoAck: false,
                consumer: consumer, cancellationToken: stoppingToken);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}