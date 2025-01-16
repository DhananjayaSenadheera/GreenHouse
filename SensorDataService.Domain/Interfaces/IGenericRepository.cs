namespace SensorDataService.Domain.Interfaces;

public interface IGenericRepository<T>
{
    Task<Guid> CreateAsync(T entity);
    Guid Update(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync();
}