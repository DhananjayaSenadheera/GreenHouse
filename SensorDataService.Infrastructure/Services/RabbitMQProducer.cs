using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;
using SensorDataService.Infrastructure.Configurations;
using SensorDataService.Infrastructure.Interfaces;

namespace SensorDataService.Infrastructure.Services;

public class RabbitMQProducer : IRabbitMQProducer
{
    private readonly IRabbitMqConnection _rabbitMqConnection;
    
    public RabbitMQProducer(IRabbitMqConnection rabbitMqConnection)
    {
        _rabbitMqConnection = rabbitMqConnection;
    }
    public async void Publish(List<SensorReading> sensorReadings)
    {
        try
        {
            using (var channel = await _rabbitMqConnection.CreateChannelAsync())
            {
                await channel.QueueDeclareAsync(
                    queue: "Sensor_Readings_Queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var properties = new BasicProperties
                {
                    Persistent = true
                };
                
                foreach (var reading in sensorReadings)
                {
                    var messageBody = JsonSerializer.Serialize(reading);
                    var body = Encoding.UTF8.GetBytes(messageBody);

                    await channel.BasicPublishAsync(
                        exchange:"",
                        routingKey:"Sensor_Readings_Queue",
                        mandatory: false,
                        basicProperties:properties,
                        body: body,
                        cancellationToken: CancellationToken.None
                    );
                }
                
                Console.WriteLine($"{sensorReadings.Count} sensor readings published to RabbitMQ.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error publishing sensor data: {e.Message}");
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }   

    }
}