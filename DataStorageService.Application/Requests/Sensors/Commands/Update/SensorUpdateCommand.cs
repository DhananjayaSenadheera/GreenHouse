using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.Sensors.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.Sensors.Commands.Update;

public class SensorUpdateCommand : IRequest<Result<bool>>
{
    public SensorUpdateDto SensorUpdateDto { get; set; }
}