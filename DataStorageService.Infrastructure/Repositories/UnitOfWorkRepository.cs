using DataStorageService.Domain.Interfaces;
using DataStorageService.Infrastructure.Configurations;

namespace DataStorageService.Infrastructure.Repositories;

public class UnitOfWorkRepository : IUnitOfWork
{
    private readonly SensorDataServiceDbContext _context;
    public UnitOfWorkRepository(SensorDataServiceDbContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}