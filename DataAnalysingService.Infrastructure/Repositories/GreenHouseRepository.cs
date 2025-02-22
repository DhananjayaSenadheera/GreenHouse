using DataAnalysingService.Domain.Entities;
using DataAnalysingService.Domain.Interfaces;

namespace DataAnalysingService.Infrastructure.Repositories;

public class GreenHouseRepository(IGenericRepository<Greenhouse> genericRepository) : IGreenHouseRepository
{
    public async Task<IEnumerable<Greenhouse>> GetAll()
    {
        return await genericRepository.GetAllAsync();
    }

    public async Task<Greenhouse> GetOneById(Guid guid)
    {
        return await genericRepository.GetByIdAsync(guid);
    }

    public async Task<Greenhouse> GetOneByCode(string greenHouseCode)
    {
        return await genericRepository.GetOneByCodeAsync(x => x.GreenHouse_Code == greenHouseCode);
    }

    public async Task<IEnumerable<Greenhouse>> GetManyByCodesAsync(List<string> greenhouseCodes)
    {
        return await genericRepository.GetManyByCodesAsync(x => greenhouseCodes.Contains(x.GreenHouse_Code));
    }
}