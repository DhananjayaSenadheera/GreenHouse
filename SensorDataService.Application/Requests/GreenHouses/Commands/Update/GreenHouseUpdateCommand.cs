using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.DTOs;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Update;

public class GreenHouseUpdateCommand : IRequest<Result<bool>>
{
    public GreenHouseUpdateDto GreenHouseUpdateDto { get; set; }
}