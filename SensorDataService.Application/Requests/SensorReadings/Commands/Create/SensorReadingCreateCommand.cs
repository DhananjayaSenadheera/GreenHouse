using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.SensorReadings.DTos;

namespace SensorDataService.Application.Requests.SensorReadings.Commands.Create;

public class SensorReadingCreateCommand : IRequest<Result<bool>>
{
   public List<SensorReadingCreateDTo> DataList { get; set; }
}