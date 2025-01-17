using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Delete;

public class GreenHouseDeleteCommandHandler : IRequestHandler<GreenHouseDeleteCommand , Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IGreenHouseRepository _greenHouseRepository;

    public GreenHouseDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IGreenHouseRepository greenHouseRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _greenHouseRepository = greenHouseRepository;
    }
    
    public async Task<Result<bool>> Handle(GreenHouseDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingGreenHouse = await _greenHouseRepository.GetOneById(request.Id);
            if (existingGreenHouse == null)
            {
                return Result<bool>.Failure("Greenhouse not found.");
            }
            await _greenHouseRepository.Delete(existingGreenHouse);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
            return Result<bool>.Failure($"Failed to delete green house{e.Message}");
        }
    }
}