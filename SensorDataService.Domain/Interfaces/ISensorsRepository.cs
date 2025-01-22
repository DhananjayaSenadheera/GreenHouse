using SensorDataService.Domain.Entities;

namespace SensorDataService.Domain.Interfaces;

public interface ISensorsRepository
{
    Task Add(Sensor sensor);
    Task<bool> Update(Sensor sensor);
    void Delete(Sensor sensor);
    Task <IEnumerable<Sensor>> GetAll();
    Task<Sensor?> GetOneById(Guid guid);
    Task<Sensor?> GetOneByIdInclude(Guid sensor_Id);
}