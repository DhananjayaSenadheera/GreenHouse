using AutoMapper;
using DataStorageService.Application.Helper;
using DataStorageService.Application.Settings;
using MediatR;
using DataStorageService.Application.Requests.GreenHouses.Validators;
using DataStorageService.Domain.Entities;
using DataStorageService.Domain.Interfaces;

namespace DataStorageService.Application.Requests.GreenHouses.Commands.Create;

public class GreenHouseCreateCommandHandler : IRequestHandler<GreenHouseCreateCommand ,Result<bool>>
{
    private readonly IGreenHouseRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly GreenHouseCodeSettings _settings;

    public GreenHouseCreateCommandHandler(IGreenHouseRepository repository, IMapper mapper, IUnitOfWork unitOfWork, GreenHouseCodeSettings settings)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _settings = settings;
    }
    public async Task<Result<bool>> Handle(GreenHouseCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result =  _mapper.Map<Greenhouse>(request.GreenHouseCreateDto);
            result.GreenHouse_Code = await _settings.GetGreenHouseCode();
            await _repository.Add(result);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure($"Failed to create Greenhouse.{ex.Message}");
        }
    }
}