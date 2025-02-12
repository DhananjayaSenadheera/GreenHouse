using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Infrastructure.Repositories;

public class SensorRepository :ISensorsRepository
{
    private readonly IGenericRepository<Sensor> _repository;
    
    public SensorRepository(IGenericRepository<Sensor> repository)
    {
        _repository = repository;
    }

    public async Task Add(Sensor sensor)
    {
       await _repository.CreateAsync(sensor);
       
    }

    public Task<bool> Update(Sensor sensor)
    {
      var result =  _repository.Update(sensor);
      return result;
    }

    public  void Delete(Sensor sensor)
    {
        _repository.DeleteAsync(sensor);
    }

    public async Task<IEnumerable<Sensor>> GetAll()
    {
       // var result = await _repository.GetAllAsync();
        var result = await _repository.GetAllAsyncInclude(x => x.Greenhouse);
        return result;
    }

    public async Task<Sensor?> GetOneById(Guid guid)
    {
        var result = await _repository.GetByIdAsync(guid);
        return result;
    }

    public async Task<Sensor?> GetOneByIdInclude(Guid guid)
    {
        var result = await _repository.GetOneAsyncInclude( y => y.Sensor_Id == guid, x=>x.Greenhouse);
        return result;
    }

    public async Task<List<Sensor>> GetSensordByGreenhouseId(Guid greenhouse_Id)
    {
        var result = await _repository.GetAllAsyncInclude(x => x.Greenhouse.GreenHouse_Id == greenhouse_Id); 
        return (List<Sensor>)result;
    }

    public async Task<IEnumerable<Sensor>> GetManyByCodesAsync(List<string>SensorCodes)
    {
        var result = await _repository.GetManyByCodesAsync(x => SensorCodes.Contains(x.Sensor_Code));
        return result;
    }
}