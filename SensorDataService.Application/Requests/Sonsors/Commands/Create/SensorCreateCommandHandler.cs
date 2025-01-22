using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Settings;
using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.Sonsors.Commands.Create;

public class SensorCreateCommandHandler : IRequestHandler<SensorCreateCommand, Result<bool>>
{
    private readonly ISensorsRepository _sensorRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGreenHouseRepository _greenHouseRepository;
    private readonly SensorCodeSettings _sensorCodeSettings;
 

    public SensorCreateCommandHandler(ISensorsRepository sensorRepository, IMapper mapper, IUnitOfWork unitOfWork, IGreenHouseRepository greenHouseRepository, IDefaultSettingRepository defaultSettingRepository, SensorCodeSettings sensorCodeSettings)
    {
        _sensorRepository = sensorRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _greenHouseRepository = greenHouseRepository;
        _sensorCodeSettings = sensorCodeSettings;
    }
    
    public async Task<Result<bool>> Handle(SensorCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingGreenhouse = await _greenHouseRepository.GetOneById(request.SensorCreateDto.GreenHouse_Id);
            if (existingGreenhouse == null)
                return Result<bool>.Failure(" Green house not exist");
            var result = _mapper.Map<Sensor>(request.SensorCreateDto);
            result.Greenhouse = existingGreenhouse;
            result.Sensor_Code = _sensorCodeSettings.GetSensorCode().Result; 
            await _sensorRepository.Add(result);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
            return Result<bool>.Failure($"Error While Inserting Sensor. { e.Message}" );
        }
    }
}