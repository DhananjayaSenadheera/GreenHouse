using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sensors.DTOs;

namespace SensorDataService.Application.Requests.Sensors.Quaries.GetAll;

public class SensorGetAllQuery : IRequest<Result<List<SensorGetDto>>>
{
    
}