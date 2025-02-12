using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sensors.DTOs;

namespace SensorDataService.Application.Requests.Sensors.Quaries.GetOne;

public class SensorGetOneQuery(Guid id) : IRequest<Result<SensorGetDto>>
{
    public Guid Sensor_Id { get; set; } = id;
}