using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Infrastructure.Repositories;

public class GreenHouseRepository:IGreenHouseRepository
{
    private readonly IGenericRepository<Greenhouse> _repository;
    
    public GreenHouseRepository(IGenericRepository<Greenhouse> repository)
    {
        _repository = repository;
    }
    public async Task Add(Greenhouse greenHouse)
    {
       await _repository.CreateAsync(greenHouse);
    }

    public Task<bool> Update(Greenhouse greenHouse)
    {
        var result = _repository.Update(greenHouse);
        return result;
    }

    public Task<Greenhouse> Delete(Greenhouse greenHouse)
    {
       _repository.DeleteAsync(greenHouse);
       return Task.FromResult(greenHouse);
       
    }

    public async Task<IEnumerable<Greenhouse>> GetAll()
    {
        var result = await _repository.GetAllAsync();
        return result;
    }

    public async Task<Greenhouse> GetOneById(Guid guid)
    {
        var result = await _repository.GetByIdAsync(guid);
        return result;
    }
}