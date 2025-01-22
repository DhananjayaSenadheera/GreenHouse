using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Infrastructure.Repositories;

public class DefaultSettingRepository : IDefaultSettingRepository
{
    private readonly IGenericRepository<DefaultSetting> _repository;

    public DefaultSettingRepository(IGenericRepository<DefaultSetting> repository)
    {
        _repository = repository;
    }
    public async Task<DefaultSetting> Get()
    {
        var result = await _repository.GetoneAsync();
        return result;
    }

    public void Update(DefaultSetting entity)
    {
        _repository.Update(entity);
    }
}