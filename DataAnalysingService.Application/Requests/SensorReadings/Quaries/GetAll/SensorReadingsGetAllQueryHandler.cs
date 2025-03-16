using AutoMapper;
using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.SensorReadings.DTos;
using DataAnalysingService.Domain.Entities;
using DataAnalysingService.Domain.Interfaces;
using MediatR;

namespace DataAnalysingService.Application.Requests.SensorReadings.Quaries.GetAll;

public class SensorReadingsGetAllQueryHandler(ISensorReadingsRepository sensorReadingsRepository, IMapper mapper)
    : IRequestHandler<SensorReadingsGetAllQuery, Result<List<SensorReadingGetDto>>>
{
    public async Task<Result<List<SensorReadingGetDto>>> Handle(SensorReadingsGetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await sensorReadingsRepository.GetAll();
            if (result == null)
            {
                return Result<List<SensorReadingGetDto>>.Failure("Failed to get sensor reading list");
            }
            return Result<List<SensorReadingGetDto>>.Success(mapper.Map<List<SensorReadingGetDto>>(result));
        }
        catch (Exception e)
        {
            return Result<List<SensorReadingGetDto>>.Failure(e.Message);
        }
   
    }
}

