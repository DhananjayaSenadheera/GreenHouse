using AutoMapper;
using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.GreenHouses.DTOs;
using DataAnalysingService.Domain.Interfaces;
using MediatR;

namespace DataAnalysingService.Application.Requests.GreenHouses.Quaries.GetAll;

public class GreenHouseGetAllQueryHandler : IRequestHandler<GreenHouseGetAllQuery , Result<List<GreenHouseGetDto>>> 
{
    private readonly IGreenHouseRepository _greenHouseRepository;
    private readonly IMapper _mapper;

    public GreenHouseGetAllQueryHandler(IGreenHouseRepository greenHouseRepository, IMapper mapper)
    {
        _greenHouseRepository = greenHouseRepository;
        _mapper = mapper;
    }
    
    public async Task<Result<List<GreenHouseGetDto>>> Handle(GreenHouseGetAllQuery request, CancellationToken cancellationToken)
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