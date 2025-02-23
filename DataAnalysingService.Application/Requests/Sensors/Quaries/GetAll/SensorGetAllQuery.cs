using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.Sensors.DTOs;
using MediatR;

namespace DataAnalysingService.Application.Requests.Sensors.Quaries.GetAll;

public class SensorGetAllQuery : IRequest<Result<List<SensorGetDto>>>
{
    
}