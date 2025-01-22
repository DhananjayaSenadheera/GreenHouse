using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sonsors.DTOs;

namespace SensorDataService.Application.Requests.Sonsors.Quaries.GetAll;

public class SensorGetAllCommand : IRequest<Result<List<SensorGetDto>>>
{
    
}