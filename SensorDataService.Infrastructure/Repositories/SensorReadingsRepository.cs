using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Infrastructure.Repositories;

public class SensorReadingsRepository : ISensorReadingsRepository
{
    private readonly IGenericRepository<SensorReading> _repository;
    
    public SensorReadingsRepository(IGenericRepository<SensorReading> repository)
    {
        _repository = repository;
    }
    
    public async Task Add(SensorReading sensorReading)
    {
        await _repository.CreateAsync(sensorReading);
    }

    public Task<bool> Update(SensorReading sensorReading)
    {
        return _repository.Update(sensorReading);
    }

    public void Delete(SensorReading sensorReading)
    {
        _repository.DeleteAsync(sensorReading);
    }

    public async Task<IEnumerable<SensorReading>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<SensorReading> GetOneById(Guid guid)
    {
        var result = await _repository.GetByIdAsync(guid);
        return result;
    }
}