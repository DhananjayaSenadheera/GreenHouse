namespace SensorDataService.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task<bool> Update(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync();
}
