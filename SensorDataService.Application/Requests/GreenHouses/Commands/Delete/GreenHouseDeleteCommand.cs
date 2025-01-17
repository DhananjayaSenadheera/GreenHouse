using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Delete;

public class GreenHouseDeleteCommand : IRequest<Result<bool>>
{
     public Guid Id { get; set; }
}