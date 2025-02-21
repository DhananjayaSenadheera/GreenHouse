using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.DTOs;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.GreenHouses.Quaries.Get.ById;

public class GreenHouseGetOneQueryHandler : IRequestHandler<GreenHouseGetOneQuery,Result<GreenHouseGetDto>>
{
    private readonly IGreenHouseRepository _greenHouseRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GreenHouseGetOneQueryHandler(IGreenHouseRepository greenHouseRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _greenHouseRepository = greenHouseRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<GreenHouseGetDto>> Handle(GreenHouseGetOneQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var exsitingGreenHouse = await _greenHouseRepository.GetOneById(request.Id);
            if (exsitingGreenHouse == null)
            {
                return Result<GreenHouseGetDto>.Failure("Failed to get green house");
            }
            return Result<GreenHouseGetDto>.Success(_mapper.Map<GreenHouseGetDto>(exsitingGreenHouse));
        }
        catch (Exception e)
        {
            return Result<GreenHouseGetDto>.Failure(e.Message);
        }
       

    }
}