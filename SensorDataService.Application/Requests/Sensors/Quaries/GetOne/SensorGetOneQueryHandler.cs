using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sensors.DTOs;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.Sensors.Quaries.GetOne;

public class SensorGetOneQueryHandler : IRequestHandler<SensorGetOneQuery, Result<SensorGetDto>>
{
    private readonly ISensorsRepository _repository;
    private readonly IMapper _mapper;

    public SensorGetOneQueryHandler(ISensorsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Result<SensorGetDto>> Handle(SensorGetOneQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var existingSensor = await _repository.GetOneByIdInclude(request.Sensor_Id);
            if (existingSensor == null)
                return Result<SensorGetDto>.Failure("Sensor not found");
            var result = _mapper.Map<SensorGetDto>(existingSensor);
            return Result<SensorGetDto>.Success(result);
        }
        catch (Exception e)
        {
            return Result<SensorGetDto>.Failure($"Error occured: {e.Message}");
        }
    }
}