

using System.Linq.Expressions;
using DataAnalysingService.Domain.Interfaces;
using DataAnalysingService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataAnalysingService.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DataAnalysingServiceDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }
        
    public async Task<T?> GetByIdAsync(Guid id)
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

    public async Task<T?> GetOneAsyncInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        try
        {
            IQueryable<T> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
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

    public async Task<T> GetoneAsync()
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync();
            return result;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected server error occurred.{e.Message}");
        }
    }

    public async Task<T> GetOneByCodeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        try
        {
            IQueryable<T> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
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

    public async Task<IEnumerable<T>> GetManyByCodesAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            var result = await _dbSet.Where(predicate).ToListAsync();
            return result;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An unexpected server error occurred: {e.Message}");
        }
    }
}