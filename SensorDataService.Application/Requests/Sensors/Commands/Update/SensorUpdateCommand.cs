using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sensors.DTOs;

namespace SensorDataService.Application.Requests.Sensors.Commands.Update;

public class SensorUpdateCommand : IRequest<Result<bool>>
{
    public SensorUpdateDto SensorUpdateDto { get; set; }
}