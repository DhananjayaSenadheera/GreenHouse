using Microsoft.EntityFrameworkCore;
using SensorDataService.Domain.Interfaces;
using SensorDataService.Infrastructure.Configurations;

namespace SensorDataService.Infrastructure.Repositories;

public class GenericRepository<T> :IGenericRepository<T> where T : class
{
    private readonly SensorDataServiceDbContext _context;
    public GenericRepository(SensorDataServiceDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> CreateAsync(T entity)
    {
        try
        {
            await  _context.AddAsync(entity);
            await _context.SaveChangesAsync();
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
        _context.Update(entity);
        _context.SaveChanges();
        var result = typeof(T).GetProperty("Id");
        return (Guid)result?.GetValue(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
       await _context.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
       return await  _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return  await _context.Set<T>().ToListAsync();
    }
}