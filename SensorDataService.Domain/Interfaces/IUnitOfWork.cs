namespace SensorDataService.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}