using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sonsors.DTOs;

namespace SensorDataService.Application.Requests.Sonsors.Commands.Create;

public class SensorCreateCommand : IRequest<Result<bool>>
{
    public SensorCreateDto SensorCreateDto { get; set; }
}