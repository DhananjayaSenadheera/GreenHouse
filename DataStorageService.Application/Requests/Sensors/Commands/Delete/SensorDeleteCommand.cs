using DataStorageService.Application.Helper;
using MediatR;

namespace DataStorageService.Application.Requests.Sensors.Commands.Delete;

public class SensorDeleteCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
}