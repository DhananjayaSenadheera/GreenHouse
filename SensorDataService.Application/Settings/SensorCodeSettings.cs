using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Settings;

public class SensorCodeSettings
{
    private readonly IDefaultSettingRepository _defaultSettingRepository;
    public SensorCodeSettings(IDefaultSettingRepository defaultSettingRepository)
    {
        _defaultSettingRepository = defaultSettingRepository;
    }
    public async Task<string>  GetSensorCode()
    {
        var settings = await _defaultSettingRepository.Get();
        var CurrentSensorCode = settings.SensorPrefix 
                                + settings.SensorCode.ToString().PadLeft((int)settings.SensorPadding, '0');
        settings.SensorCode++;
        _defaultSettingRepository.Update(settings);
        return CurrentSensorCode;
    }
}