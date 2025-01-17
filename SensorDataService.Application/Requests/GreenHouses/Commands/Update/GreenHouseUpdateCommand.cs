using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Update;

public class GreenHouseUpdateCommand : IRequest<Result<bool>>
{
    public UpdateDto UpdateDto { get; set; }
}