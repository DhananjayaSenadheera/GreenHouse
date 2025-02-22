using System.Linq.Expressions;

namespace DataStorageService.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task<bool> Update(T entity);
    void DeleteAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<T?> GetOneAsyncInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsyncInclude(params Expression<Func<T, object>>[] includes);
    Task<T> GetoneAsync();
    Task<T> GetOneByCodeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    Task<IEnumerable<T>> GetManyByCodesAsync(Expression<Func<T, bool>> predicate);
}
