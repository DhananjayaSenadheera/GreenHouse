using MediatR;
using SensorDataService.Application.Helper;

namespace SensorDataService.Application.Requests.Sensors.Commands.Delete;

public class SensorDeleteCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
}