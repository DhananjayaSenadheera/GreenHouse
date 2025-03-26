using DataAnalysingService.Domain.Entities;

namespace DataAnalysingService.Domain.Interfaces;

public interface ISensorsRepository
{
    Task <IEnumerable<Sensor>> GetAll();
    Task<List<Sensor>> GetAllInclude();
    Task<Sensor?> GetOneById(Guid guid);
    Task<Sensor?> GetOneByIdInclude(Guid sensor_Id);
    Task<List<Sensor>> GetSensordByGreenhouseId(Guid greenhouse_Id);
    Task<IEnumerable<Sensor>> GetManyByCodesAsync(List<string> SensorCodes);
}