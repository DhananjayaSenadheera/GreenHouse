namespace DataAnalysingService.Application.Requests.SensorReadings.DTos;

public class SensorReadingGetDto
{
    public string Sensor_Code { get; set; }
    public string Sensor_Name { get; set; }
    public string GrnHouse_code { get; set; }
    public string GrnHouse_name { get; set; }
    public double Value { get; set; }
    public string Unit { get; set; }
    public string Plot_No { get; set; }
    public DateTime Created_Date { get; set; }
}