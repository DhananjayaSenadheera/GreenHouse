using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.Sensors.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.Sensors.Quaries.GetOne;

public class SensorGetOneQuery(Guid id) : IRequest<Result<SensorGetDto>>
{
    public Guid Sensor_Id { get; set; } = id;
}