using Microsoft.EntityFrameworkCore;

namespace SensorDataService.Domain.Entities;

public class SensorReading
{
    public Guid Id { get; set; }
    public Guid Sensor_Id { get; set; }
    public double Value { get; set; }
    public string Unit { get; set; }
    public DateTime Timestamp { get; set; }
    public Sensor Sensor { get; set; }
}