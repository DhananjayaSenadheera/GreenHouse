using DataAnalysingService.Domain.Entities;
using DataAnalysingService.Domain.Interfaces;

namespace DataAnalysingService.Infrastructure.Repositories;

public class SensorReadingRepository(IGenericRepository<SensorReading> repository) : ISensorReadingsRepository
{
    public async Task<IEnumerable<SensorReading>> GetAll()
    {
        return await repository.GetAllAsync();
    }

    public async Task<SensorReading> GetOneById(Guid guid)
    {
        return await repository.GetByIdAsync(guid);
    }
}