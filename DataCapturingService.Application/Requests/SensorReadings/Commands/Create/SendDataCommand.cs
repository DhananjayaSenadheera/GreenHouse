
using DataCapturingService.Domain.Domain;
using MediatR;

namespace DataCapturingService.Application.Requests.SensorReadings.Commands.Create;

public class SendDataCommand : IRequest
{
    public List<SensorReading> DataList { get; set; }
}