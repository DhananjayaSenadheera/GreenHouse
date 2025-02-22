using AutoMapper;
using DataStorageService.Application.Helper;
using MediatR;
using DataStorageService.Domain.Interfaces;

namespace DataStorageService.Application.Requests.Sensors.Commands.Update;

public class SensorUpdateCommandHandler : IRequestHandler<SensorUpdateCommand , Result<bool>>
{
    private readonly ISensorsRepository _sensorRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGreenHouseRepository _greenHouseRepository;

    public SensorUpdateCommandHandler(ISensorsRepository sensorRepository, IMapper mapper, IUnitOfWork unitOfWork, IGreenHouseRepository greenHouseRepository)
    {
        _sensorRepository = sensorRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _greenHouseRepository = greenHouseRepository;
    }
    
    public async Task<Result<bool>> Handle(SensorUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingSensor = await _sensorRepository.GetOneById(request.SensorUpdateDto.Sensor_Id);
            var esxistingGreenHouse = await _greenHouseRepository.GetOneById(request.SensorUpdateDto.GreenHouse_Id);
            
            if (existingSensor == null)
                return Result<bool>.Failure("Failed to find sensor");
            if (esxistingGreenHouse == null)
                return Result<bool>.Failure("Failed to find green house");
        
            var sensor = _mapper.Map(request.SensorUpdateDto, existingSensor);
            sensor.Greenhouse = esxistingGreenHouse;
            await _sensorRepository.Update(sensor);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
            return Result<bool>.Failure($"Error while updating sensor data.{e.Message}" );
        }
    }
}