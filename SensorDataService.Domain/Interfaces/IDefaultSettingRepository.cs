using SensorDataService.Domain.Entities;

namespace SensorDataService.Domain.Interfaces;

public interface IDefaultSettingRepository
{
    Task<DefaultSetting> Get();
    void Update(DefaultSetting setting);
}