using DataAnalysingService.Domain.Entities;
using DataAnalysingService.Domain.Interfaces;

namespace DataAnalysingService.Infrastructure.Repositories;

public class SensorRepository(IGenericRepository<Sensor> repository) : ISensorsRepository
{
    public async Task<IEnumerable<Sensor>> GetAll()
    {
        return await repository.GetAllAsync();
    }

    public async Task<List<Sensor>> GetAllInclude()
    {
        var result = await repository.GetAllAsyncInclude(x => x.Greenhouse); 
        return result.ToList();
    }

    public async Task<Sensor?> GetOneById(Guid guid)
    {
        return await repository.GetByIdAsync(guid);
    }

    public async Task<Sensor?> GetOneByIdInclude(Guid guid)
    {
        return await repository.GetOneAsyncInclude(x=>x.Sensor_Id == guid , x => x.Greenhouse);
    }

    public async Task<List<Sensor>> GetSensordByGreenhouseId(Guid greenhouse_Id)
    {
        var result = await repository.GetAllAsyncInclude(x => x.Greenhouse.GreenHouse_Id == greenhouse_Id); 
        return (List<Sensor>)result;
    }

    public async Task<IEnumerable<Sensor>> GetManyByCodesAsync(List<string> SensorCodes)
    {
        var result = await repository.GetManyByCodesAsync(x => SensorCodes.Contains(x.Sensor_Code));
        return result;
    }
}