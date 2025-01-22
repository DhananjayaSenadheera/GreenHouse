namespace SensorDataService.Application.Requests.GreenHouses.Dtos;

public class GreenHouseUpdateDto
{
    public Guid GreenHouse_Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
}