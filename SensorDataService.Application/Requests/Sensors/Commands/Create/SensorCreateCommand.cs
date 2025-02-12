using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sensors.DTOs;

namespace SensorDataService.Application.Requests.Sensors.Commands.Create;

public class SensorCreateCommand : IRequest<Result<bool>>
{
    public SensorCreateDto SensorCreateDto { get; set; }
}