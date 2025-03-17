using AutoMapper;
using DataStorageService.Application.Helper;
using MediatR;
using DataStorageService.Application.Requests.Sensors.DTOs;
using DataStorageService.Domain.Entities;
using DataStorageService.Domain.Interfaces;

namespace DataStorageService.Application.Requests.SensorReadings.Commands.Create;

public class SensorReadingCreateCommandHandler(
    ISensorsRepository sensorRepository,
    IGreenHouseRepository greenHouseRepository,
    ISensorReadingsRepository sensorReadingsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<SensorReadingCreateCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(SensorReadingCreateCommand request, CancellationToken cancellationToken)
    {
        //  Get all unique greenhouse codes & sensor codes
        var greenhouseCodes = request.DataList.Select(d => d.GrnHouse_code).Distinct().ToList();
        var sensorCodes = request.DataList.Select(d => d.Sensor_Code).Distinct().ToList();

        // Fetch existing greenhouses
        var greenhouses = await greenHouseRepository.GetManyByCodesAsync(greenhouseCodes);
        var greenhouseMap = greenhouses.ToDictionary(g => g.GreenHouse_Code, g => g.GreenHouse_Id);

        // Fetch existing sensors
        var sensors = await sensorRepository.GetManyByCodesAsync(sensorCodes);
        var sensorMap = sensors.ToDictionary(s => s.Sensor_Code, s => s.Sensor_Id);

        //  Validate if all requested greenhouses exist
        var missingGreenhouses = greenhouseCodes.Except(greenhouseMap.Keys).ToList();
        if (missingGreenhouses.Any())
        {
            return Result<bool>.Failure(
                $"The following greenhouse codes were not found: {string.Join(", ", missingGreenhouses)}");
        }

        //  Validate if all requested sensors exist
        var missingSensors = sensorCodes.Except(sensorMap.Keys).ToList();
        if (missingSensors.Any())
        {
            return Result<bool>.Failure(
                $"The following sensor codes were not found: {string.Join(", ", missingSensors)}");
        }

        //Filter valid sensor readings
        var validData = request.DataList
            .Where(d => greenhouseMap.ContainsKey(d.GrnHouse_code) && sensorMap.ContainsKey(d.Sensor_Code))
            .Select(d => new
            {
                d.GrnHouse_code,
                d.Sensor_Code,
                Sensor_Id = sensorMap[d.Sensor_Code],
                d.Value,
                d.Unit,
                d.Plot_No,
                d.CreatedAt
            })
            .ToList();

        var sensorReadings = validData.Select(d => new SensorReading
        {
            Sensor_Id = sensorMap[d.Sensor_Code],
            Value = d.Value,
            Unit = d.Unit,
            Plot_No = d.Plot_No,
            CreatedAt = d.CreatedAt
        }).ToList();
        
        
        foreach (var reading in sensorReadings)
        {
            var result = mapper.Map<SensorReading>(reading);
            await sensorReadingsRepository.Add(result);
        }
        await unitOfWork.CommitAsync();
        return Result<bool>.Success(true);
    }
}
//     public async Task<Result<bool>> Handle(SensorReadingCreateCommand request, CancellationToken cancellationToken)
// {
//     // Get all unique greenhouse codes & sensor codes
//     var greenhouseCodes = request.DataList.Select(d => d.GrnHouse_code).Distinct().ToList();
//     var sensorCodes = request.DataList.Select(d => d.Sensor_Code).Distinct().ToList();
//
//     // Fetch existing greenhouses
//     var greenhouses = await _greenHouseRepository.GetManyByCodesAsync(greenhouseCodes);
//     var greenhouseMap = greenhouses.ToDictionary(g => g.GreenHouse_Code, g => g.GreenHouse_Id);
//
//     // Fetch existing sensors
//     var sensors = await _sensorRepository.GetManyByCodesAsync(sensorCodes);
//     var sensorMap = sensors.ToDictionary(s => s.Sensor_Code, s => s.Sensor_Id);
//
//     // Identify missing greenhouses and sensors
//     var missingGreenhouses = greenhouseCodes.Except(greenhouseMap.Keys).ToList();
//     var missingSensors = sensorCodes.Except(sensorMap.Keys).ToList();
//
//     // Filter valid sensor readings
//     var validData = request.DataList
//         .Where(d => greenhouseMap.ContainsKey(d.GrnHouse_code) && sensorMap.ContainsKey(d.Sensor_Code))
//         .ToList();
//
//     
//     if (!validData.Any())
//     {
//         return Result<bool>.Failure("No valid greenhouse or sensor data found.");
//     }
//
// 
//    
//     foreach (var data in validData)
//     {
//         var newSensorReading = new SensorReadingCreateDTo()
//         {
//             GrnHouse_code = greenhouseMap[data.GrnHouse_code].ToString(),
//             Sensor_Code = sensorMap[data.Sensor_Code].ToString(),
//             Value = data.Value,
//             Unit = data.Unit,
//         };
//
//       //  await _sensorReadingRepository.Add(newSensorReading);
//     }
//
//     
//     var warnings = new List<string>();
//     if (missingGreenhouses.Any())
//     {
//         warnings.Add($"The following greenhouse codes were not found: {string.Join(", ", missingGreenhouses)}");
//     }
//     if (missingSensors.Any())
//     {
//         warnings.Add($"The following sensor codes were not found: {string.Join(", ", missingSensors)}");
//     }
//
//     return warnings.Any()
//         ? Result<bool>.SuccessWithWarnings(true, string.Join("; ", warnings))
//         : Result<bool>.Success(true);
// }
