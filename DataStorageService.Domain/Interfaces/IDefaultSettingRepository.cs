using DataStorageService.Domain.Entities;

namespace DataStorageService.Domain.Interfaces;

public interface IDefaultSettingRepository
{
    Task<DefaultSetting> Get();
    void Update(DefaultSetting setting);
}