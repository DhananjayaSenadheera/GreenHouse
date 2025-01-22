using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.GreenHouses.Quaries.GetAll;

public class GreeHouseGetAllCommandHandler : IRequestHandler<GreeHouseGetAllCommand , Result<List<GreenHouseGetDto>>> 
{
    private readonly IGreenHouseRepository _greenHouseRepository;
    private readonly IMapper _mapper;

    public GreeHouseGetAllCommandHandler(IGreenHouseRepository greenHouseRepository, IMapper mapper)
    {
        _greenHouseRepository = greenHouseRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<GreenHouseGetDto>>> Handle(GreeHouseGetAllCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _greenHouseRepository.GetAll();
            if (result == null)
            {
                return Result<List<GreenHouseGetDto>>.Failure("Failed to get green house list");
            }
            return Result<List<GreenHouseGetDto>>.Success(_mapper.Map<List<GreenHouseGetDto>>(result));
        }
        catch (Exception e)
        {
            return Result<List<GreenHouseGetDto>>.Failure(e.Message);
        }
       
    }
}