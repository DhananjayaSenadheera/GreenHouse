using DataStorageService.Domain.Entities;
using DataStorageService.Domain.Interfaces;

namespace DataStorageService.Infrastructure.Repositories;

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