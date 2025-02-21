using DataCapturingService.Domain.Interfaces;
using MediatR;

namespace DataCapturingService.Application.Requests.SensorReadings.Commands.Create;

public class SendDataCommandHandler(IRabbitMqProducer rabbitMqProducer) : IRequestHandler<SendDataCommand>
{
    public Task Handle(SendDataCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var list = request.DataList;
            rabbitMqProducer.Publish(list);
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}