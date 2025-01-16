using SensorDataService.Domain.Entities;

namespace SensorDataService.Domain.Interfaces;

public interface ISensorsRepository
{
    Task<Guid> Add(Sensor sensor);
    Guid Update(Sensor sensor);
    void Delete(Sensor sensor);
    Task <IEnumerable<Sensor>> GetAll();
    Task <Sensor> GetOneById(Guid guid);
}