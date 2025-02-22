using DataStorageService.Domain.Entities;

namespace DataStorageService.Domain.Interfaces;

public interface IGreenHouseRepository
{
    Task Add(Greenhouse greenHouse);
    Task<bool> Update(Greenhouse greenHouse);
    Task <Greenhouse> Delete(Greenhouse greenHouse);
    Task <IEnumerable<Greenhouse>> GetAll();
    Task <Greenhouse> GetOneById(Guid guid);
    Task <Greenhouse> GetOneByCode(string GreenHouseCode);
    Task<IEnumerable<Greenhouse>> GetManyByCodesAsync(List<string> greenhouseCodes);
}