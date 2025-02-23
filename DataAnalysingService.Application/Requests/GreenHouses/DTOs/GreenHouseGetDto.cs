using DataAnalysingService.Domain.Entities;

namespace DataAnalysingService.Application.Requests.GreenHouses.DTOs;

public class GreenHouseGetDto
{
    public Guid GreenHouse_Id { get; set; }
    public string GreenHouse_Code { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public ICollection<Sensor> Sensors { get; set; }
}