using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnalysingService.Domain.Entities;

public class SensorReading
{
    public Guid Id { get; set; }

    public double Value { get; set; }
    public string Unit { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    // Foreign Key
    [ForeignKey("Sensor")]
    public Guid Sensor_Id { get; set; }

    // Navigation Property
    public Sensor Sensor { get; set; }
}