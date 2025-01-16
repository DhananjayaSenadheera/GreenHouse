using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Create;

public class GreenHouseCreateCommand : IRequest<Result<bool>>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    
    public CreateDto CreateDto { get; set; }
}