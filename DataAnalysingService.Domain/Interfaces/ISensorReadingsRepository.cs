using DataAnalysingService.Domain.Entities;

namespace DataAnalysingService.Domain.Interfaces;

public interface ISensorReadingsRepository
{
    Task <IEnumerable<SensorReading>> GetAll();
    Task <SensorReading> GetOneById(Guid guid);
}