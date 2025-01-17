using SensorDataService.Domain.Entities;

namespace SensorDataService.Application.Requests.GreenHouses.Dtos;

public class GetDto
{
    public Guid GreenHouse_Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public ICollection<Sensor> Sensors { get; set; }
}