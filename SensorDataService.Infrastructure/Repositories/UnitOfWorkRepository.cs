using SensorDataService.Domain.Interfaces;
using SensorDataService.Infrastructure.Configurations;

namespace SensorDataService.Infrastructure.Repositories;

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