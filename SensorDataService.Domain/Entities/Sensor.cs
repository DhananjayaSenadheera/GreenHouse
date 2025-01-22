using System.ComponentModel.DataAnnotations;

namespace SensorDataService.Domain.Entities;

public class Sensor
{
    [Key]
    public Guid Sensor_Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Greenhouse Greenhouse { get; set; }
    public ICollection<SensorReading> SensorReadings { get; set; }
}