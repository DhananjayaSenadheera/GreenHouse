using Microsoft.EntityFrameworkCore;
using SensorDataService.Domain.Interfaces;
using SensorDataService.Infrastructure.Configurations;

namespace SensorDataService.Infrastructure.Repositories;

public class GenericRepository<T> :IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    public GenericRepository(SensorDataServiceDbContext context, DbSet<T> dbSet)
    {
        _dbSet = dbSet;
    }
    public async Task<Guid> CreateAsync(T entity)
    {
        try
        {
            await  _dbSet.AddAsync(entity);
            var result = typeof(T).GetProperty("Id");
            return (Guid)result?.GetValue(entity);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An unexpected error occurred.{ex.Message}");
        }
         
    }

    public Guid Update(T entity)
    {
        _dbSet.Update(entity);
        var result = typeof(T).GetProperty("Id");
        return (Guid)result?.GetValue(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
       return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return  await _dbSet.ToListAsync();
    }
}