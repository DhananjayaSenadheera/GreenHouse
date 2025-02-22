using DataAnalysingService.Domain.Entities;

namespace DataAnalysingService.Domain.Interfaces;

public interface IGreenHouseRepository
{
    Task <IEnumerable<Greenhouse>> GetAll();
    Task <Greenhouse> GetOneById(Guid guid);
    Task <Greenhouse> GetOneByCode(string GreenHouseCode);
    Task<IEnumerable<Greenhouse>> GetManyByCodesAsync(List<string> greenhouseCodes);
}