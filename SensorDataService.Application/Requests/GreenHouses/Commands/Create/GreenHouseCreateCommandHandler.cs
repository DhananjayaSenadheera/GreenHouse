using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;
using SensorDataService.Application.Requests.GreenHouses.Validators;
using SensorDataService.Application.Settings;
using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Create;

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