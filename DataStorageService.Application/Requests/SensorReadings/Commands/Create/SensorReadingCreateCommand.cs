using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.SensorReadings.DTos;
using MediatR;

namespace DataStorageService.Application.Requests.SensorReadings.Commands.Create;

public class SensorReadingCreateCommand : IRequest<Result<bool>>
{
   public List<SensorReadingCreateDTo> DataList { get; set; }
}