namespace DataCapturingService.Domain.Domain;

public class SensorReading
{
    public string Sensor_Code { get; set; }
    public string GrnHouse_code { get; set; }
    public double Value { get; set; }
    public string Unit { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Plot_No { get; set; }

}