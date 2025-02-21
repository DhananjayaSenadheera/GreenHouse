using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.DTOs;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Create;

public class GreenHouseCreateCommand : IRequest<Result<bool>>
{
    public GreenHouseCreateDto GreenHouseCreateDto { get; set; }
}