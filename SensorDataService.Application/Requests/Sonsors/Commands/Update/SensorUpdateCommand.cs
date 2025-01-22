using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sonsors.DTOs;

namespace SensorDataService.Application.Requests.Sonsors.Commands.Update;

public class SensorUpdateCommand : IRequest<Result<bool>>
{
    public SensorUpdateDto SensorUpdateDto { get; set; }
}