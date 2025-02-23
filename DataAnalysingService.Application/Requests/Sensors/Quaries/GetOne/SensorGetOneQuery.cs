using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.Sensors.DTOs;
using MediatR;

namespace DataAnalysingService.Application.Requests.Sensors.Quaries.GetOne;

public class SensorGetOneQuery(Guid id) : IRequest<Result<SensorGetDto>>
{
    public Guid Sensor_Id { get; set; } = id;
}