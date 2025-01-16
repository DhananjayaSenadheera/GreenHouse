using SensorDataService.Domain.Entities;

namespace SensorDataService.Domain.Interfaces;

public interface IGreenHouseRepository
{
    Task<Guid> Add(Greenhouse greenHouse);
    Guid Update(Greenhouse greenHouse);
    Task <Greenhouse> Delete(Greenhouse greenHouse);
    Task <IEnumerable<Greenhouse>> GetAll();
    Task <Greenhouse> GetOneById(Guid guid);
}