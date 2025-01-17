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
        var result = await _repository.GetAllAsync();
        return result;
    }

    public async Task<Sensor> GetOneById(Guid guid)
    {
        var result = await _repository.GetByIdAsync(guid);
        return result;
    }
}