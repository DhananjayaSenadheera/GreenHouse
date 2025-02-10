using System.ComponentModel.DataAnnotations;

namespace SensorDataService.Domain.Entities;

public class DefaultSetting
{
    public int Id { get; set; }

    [MaxLength(10)]
    public string SensorPrefix { get; set; }
    public int? SensorPadding { get; set; }
    public int? SensorCode { get; set; }
    public string GreenHousePrefix { get; set; }
    public int? GreenHousePadding { get; set; }
    public int? GreenHouseCode { get; set; }
}