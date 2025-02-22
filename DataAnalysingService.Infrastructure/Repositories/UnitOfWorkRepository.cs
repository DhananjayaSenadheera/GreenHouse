using DataAnalysingService.Domain.Interfaces;
using DataAnalysingService.Infrastructure.Configurations;

namespace DataAnalysingService.Infrastructure.Repositories;

public class UnitOfWorkRepository : IUnitOfWork
{
    private readonly DataAnalysingServiceDbContext _context;

    public UnitOfWorkRepository(DataAnalysingServiceDbContext context)
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