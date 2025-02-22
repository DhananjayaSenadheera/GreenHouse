using AutoMapper;
using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.GreenHouses.DTOs;
using MediatR;
using DataStorageService.Domain.Interfaces;

namespace DataStorageService.Application.Requests.GreenHouses.Quaries.Get.ByCode;

public class GreenhouseGetOneByCodeQueryHandler : IRequestHandler<GreenHouseGetOneByCodeQuery, Result<GreenHouseGetDto>>
{
    private readonly IGreenHouseRepository _greenHouseRepository;
    private readonly IMapper _mapper;
    
    public GreenhouseGetOneByCodeQueryHandler(IGreenHouseRepository greenHouseRepository, IMapper mapper)
    {
        _greenHouseRepository = greenHouseRepository;
        _mapper = mapper;
    }
    public async Task<Result<GreenHouseGetDto>> Handle(GreenHouseGetOneByCodeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var greenhouse = await _greenHouseRepository.GetOneByCode(request.Code);
            if(greenhouse == null)
            {
                return Result<GreenHouseGetDto>.Failure("Invalid code");
            }
            return Result<GreenHouseGetDto>.Success(_mapper.Map<GreenHouseGetDto>(greenhouse));
        }
        catch (Exception e)
        {
            return Result<GreenHouseGetDto>.Failure(e.Message);
        }
    }
}