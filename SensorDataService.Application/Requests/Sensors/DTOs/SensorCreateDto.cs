namespace SensorDataService.Application.Requests.Sensors.DTOs;

public class SensorCreateDto
{
    public Guid GreenHouse_Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}