using DataAnalysingService.Domain.Entities;

namespace DataAnalysingService.Application.Requests.Sensors.DTOs;

public class SensorGetDto
{
    //public Guid Sensor_Id { get; set; }
    public string Sensor_Code { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public string GreenHouse_Code  { get; set; }
    public string GreenHouse_Name { get; set; }
    //public ICollection<SensorReading> SensorReadings { get; set; }
}