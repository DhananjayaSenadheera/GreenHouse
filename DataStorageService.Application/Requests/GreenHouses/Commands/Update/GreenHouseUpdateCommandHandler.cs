using AutoMapper;
using DataStorageService.Application.Helper;
using MediatR;
using DataStorageService.Domain.Entities;
using DataStorageService.Domain.Interfaces;

namespace DataStorageService.Application.Requests.GreenHouses.Commands.Update;

public class GreenHouseUpdateCommandHandler : IRequestHandler<GreenHouseUpdateCommand,Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IGreenHouseRepository _greenHouseRepository;

    public GreenHouseUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IGreenHouseRepository greenHouseRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _greenHouseRepository = greenHouseRepository;
    }
    public async Task<Result<bool>> Handle(GreenHouseUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingGreenHouse =await _greenHouseRepository.GetOneById(request.GreenHouseUpdateDto.GreenHouse_Id);
            if (existingGreenHouse == null)
            {
                return Result<bool>.Failure($"Green house with id: {request.GreenHouseUpdateDto.Name} was not found");
            }
            var result =  _mapper.Map(request.GreenHouseUpdateDto, existingGreenHouse);
            await _greenHouseRepository.Update(result);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
           return Result<bool>.Failure("Error has occured while updating green house");
        }
        
    }
}