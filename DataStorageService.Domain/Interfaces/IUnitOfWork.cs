namespace DataStorageService.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}