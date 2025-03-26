using System.ComponentModel.DataAnnotations;
using DataAnalysingService.Domain.Enum;

namespace DataAnalysingService.Domain.Entities;

public class Greenhouse
{
    [Key]
    public Guid GreenHouse_Id { get; set; }
    public string GreenHouse_Code { get; set; }
    public decimal SizeInSquareFeet { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }

     public Status Status { get; set; }
   // public ICollection<Sensor> Sensors { get; set; }
}