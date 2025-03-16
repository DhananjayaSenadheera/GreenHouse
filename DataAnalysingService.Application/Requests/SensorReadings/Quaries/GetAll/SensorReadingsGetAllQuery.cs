using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.SensorReadings.DTos;
using MediatR;

namespace DataAnalysingService.Application.Requests.SensorReadings.Quaries.GetAll;

public class SensorReadingsGetAllQuery : IRequest<Result<List<SensorReadingGetDto>>>
{
    
}