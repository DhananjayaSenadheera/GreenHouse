using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sonsors.DTOs;

namespace SensorDataService.Application.Requests.Sonsors.Quaries.GetOne;

public class SensorGetOneCommand(Guid id) : IRequest<Result<SensorGetDto>>
{
    public Guid Sensor_Id { get; set; } = id;
}