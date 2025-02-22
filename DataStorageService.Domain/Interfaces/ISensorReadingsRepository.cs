using DataStorageService.Domain.Entities;

namespace DataStorageService.Domain.Interfaces;

public interface ISensorReadingsRepository
{
    Task Add(SensorReading sensorReading);
    Task<bool> Update(SensorReading sensorReading);
    void Delete(SensorReading sensorReading);
    Task <IEnumerable<SensorReading>> GetAll();
    Task <SensorReading> GetOneById(Guid guid);
}