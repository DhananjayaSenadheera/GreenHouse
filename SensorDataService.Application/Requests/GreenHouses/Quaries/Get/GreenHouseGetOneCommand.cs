using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;

namespace SensorDataService.Application.Requests.GreenHouses.Quaries.Get;

public class GreenHouseGetOneCommand(Guid id) : IRequest<Result<GreenHouseGetDto>>
{ 
    public Guid Id { get; set; } = id;
}