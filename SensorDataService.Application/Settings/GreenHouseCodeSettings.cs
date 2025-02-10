using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Settings;

public class GreenHouseCodeSettings
{
    private readonly IDefaultSettingRepository _defaultSettingRepository;
    
    public GreenHouseCodeSettings(IDefaultSettingRepository defaultSettingRepository)
    {
        _defaultSettingRepository = defaultSettingRepository;
    }
    
    public async Task<string>  GetGreenHouseCode()
    {
        var settings = await _defaultSettingRepository.Get();
        var CurrentGreenHouseCode = settings.GreenHousePrefix 
                                + settings.GreenHouseCode.ToString().PadLeft((int)settings.GreenHousePadding, '0');
        settings.GreenHouseCode++;
        _defaultSettingRepository.Update(settings);
        return CurrentGreenHouseCode;
    }
}