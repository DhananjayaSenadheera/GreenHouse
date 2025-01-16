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
    public async Task<Guid> Add(Greenhouse greenHouse)
    {
        var id = await _repository.CreateAsync(greenHouse);
        return id;
    }

    public Guid Update(Greenhouse greenHouse)
    {
        var id = _repository.Update(greenHouse);
        return id;
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