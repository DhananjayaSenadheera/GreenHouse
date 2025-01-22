using System.Linq.Expressions;
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
            throw new ApplicationException($"An unexpected server error occurred.{ex.Message}");
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
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }
    }

    public void DeleteAsync(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }
         
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        try
        {
            return await _dbSet.FindAsync(id);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }
      
    }
    
    public async Task<T?> GetOneAsyncInclude(Expression<Func<T, bool>> predicate,params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            var res = await query.FirstOrDefaultAsync(predicate);
            return res;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }
      
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            var result = await _dbSet.ToListAsync();
            return  result;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }
    }

    public async Task<IEnumerable<T>> GetAllAsyncInclude(params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            
            var result = await query.ToListAsync();
            return result;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }
    }
}