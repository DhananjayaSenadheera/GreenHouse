using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.Sensors.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.Sensors.Quaries.GetAll;

public class SensorGetAllQuery : IRequest<Result<List<SensorGetDto>>>
{
    
}