namespace DataAnalysingService.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}