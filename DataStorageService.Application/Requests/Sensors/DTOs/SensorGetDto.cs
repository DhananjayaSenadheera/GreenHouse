using DataStorageService.Domain.Entities;

namespace DataStorageService.Application.Requests.Sensors.DTOs;

public class SensorGetDto
{
    public Guid Sensor_Id { get; set; }
    public string Sensor_Code { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public virtual Greenhouse Greenhouse { get; set; }
    //public ICollection<SensorReading> SensorReadings { get; set; }
}