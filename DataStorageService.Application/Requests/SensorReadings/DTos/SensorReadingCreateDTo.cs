namespace DataStorageService.Application.Requests.SensorReadings.DTos;

public class SensorReadingCreateDTo
{
    public string Sensor_Code { get; set; }
    public string GrnHouse_code { get; set; }
    public double Value { get; set; }
    public string Unit { get; set; }
}