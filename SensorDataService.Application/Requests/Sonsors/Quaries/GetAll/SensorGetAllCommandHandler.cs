using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.Sonsors.DTOs;
using SensorDataService.Domain.Interfaces;


namespace SensorDataService.Application.Requests.Sonsors.Quaries.GetAll;

public class SensorGetAllCommandHandler : IRequestHandler<SensorGetAllCommand , Result<List<SensorGetDto>>>
{
    private readonly ISensorsRepository _sensorsRepository;
    private readonly IMapper _mapper;

    public SensorGetAllCommandHandler(ISensorsRepository sensorsRepository, IMapper mapper)
    {
        _sensorsRepository = sensorsRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<SensorGetDto>>> Handle(SensorGetAllCommand request, CancellationToken cancellationToken)
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