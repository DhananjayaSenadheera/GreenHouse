using Microsoft.EntityFrameworkCore;
using SensorDataService.Domain.Interfaces;
using SensorDataService.Infrastructure.Configurations;

namespace SensorDataService.Infrastructure.Repositories;

public class GenericRepository<T> :IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    public GenericRepository(SensorDataServiceDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }
    public async Task CreateAsync(T entity)
    {
        try
        {
            await  _dbSet.AddAsync(entity);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An unexpected error occurred.{ex.Message}");
        }
         
    }

    public Task<bool> Update(T entity)
    {
        try
        {
            _dbSet.Update(entity);
             return Task.FromResult(true);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected error occurred.{e.Message}");
        }
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