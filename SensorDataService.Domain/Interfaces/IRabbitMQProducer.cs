using SensorDataService.Domain.Entities;

namespace SensorDataService.Domain.Interfaces;

public interface IRabbitMQProducer
{
    void Publish(List<SensorReading> sensorReadings);
}