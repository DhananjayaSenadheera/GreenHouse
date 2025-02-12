using FluentValidation;
using SensorDataService.Application.Requests.Sensors.Commands.Update;

namespace SensorDataService.Application.Requests.Sensors.Validators;

public class SensorUpdateCommandValidator : AbstractValidator<SensorUpdateCommand>
{
    public SensorUpdateCommandValidator()
    {
        RuleFor(x => x.SensorUpdateDto.Sensor_Id)
            .NotEmpty().WithMessage("SensorId is required");
        
        RuleFor(x => x.SensorUpdateDto.GreenHouse_Id)
            .NotEmpty().WithMessage("GreenHouseId is required");
    }
}