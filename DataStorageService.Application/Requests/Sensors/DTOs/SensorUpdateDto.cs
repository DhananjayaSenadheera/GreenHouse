namespace DataStorageService.Application.Requests.Sensors.DTOs;

public class SensorUpdateDto
{
    public Guid Sensor_Id { get; set; }
    public Guid GreenHouse_Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}