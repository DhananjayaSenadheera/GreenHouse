using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.Sensors.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.Sensors.Commands.Create;

public class SensorCreateCommand : IRequest<Result<bool>>
{
    public SensorCreateDto SensorCreateDto { get; set; }
}