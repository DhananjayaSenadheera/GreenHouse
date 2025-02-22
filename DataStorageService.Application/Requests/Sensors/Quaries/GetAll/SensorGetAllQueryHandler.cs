using AutoMapper;
using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.Sensors.DTOs;
using MediatR;
using DataStorageService.Domain.Interfaces;

namespace DataStorageService.Application.Requests.Sensors.Quaries.GetAll;

public class SensorGetAllQueryHandler : IRequestHandler<SensorGetAllQuery , Result<List<SensorGetDto>>>
{
    private readonly ISensorsRepository _sensorsRepository;
    private readonly IMapper _mapper;

    public SensorGetAllQueryHandler(ISensorsRepository sensorsRepository, IMapper mapper)
    {
        _sensorsRepository = sensorsRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<SensorGetDto>>> Handle(SensorGetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _sensorsRepository.GetAll();
            if (result is null)
                return Result<List<SensorGetDto>>.Failure("Error while retrieving sensors");
            return Result<List<SensorGetDto>>.Success(_mapper.Map<List<SensorGetDto>>(result));
        }
        catch (Exception e)
        {
            return Result<List<SensorGetDto>>.Failure($"Error while retrieving sensors{e.Message}");
        }
    }
}