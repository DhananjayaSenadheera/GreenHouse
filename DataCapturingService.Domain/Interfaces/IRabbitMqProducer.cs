using DataCapturingService.Domain.Domain;

namespace DataCapturingService.Domain.Interfaces;

public interface IRabbitMqProducer
{
    void Publish(List<SensorReading> sensorReadings);
}