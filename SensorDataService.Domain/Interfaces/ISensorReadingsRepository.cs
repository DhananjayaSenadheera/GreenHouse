using SensorDataService.Domain.Entities;

namespace SensorDataService.Domain.Interfaces;

public interface ISensorReadingsRepository
{
    Task<Guid> Add(SensorReading sensorReading);
    Guid Update(SensorReading sensorReading);
    void Delete(SensorReading sensorReading);
    Task <IEnumerable<SensorReading>> GetAll();
    Task <SensorReading> GetOneById(Guid guid);
}