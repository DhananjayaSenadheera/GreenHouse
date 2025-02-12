using FluentValidation;
using SensorDataService.Application.Requests.Sensors.Quaries.GetOne;

namespace SensorDataService.Application.Requests.Sensors.Validators;

public class SensorGetOneCommandValidator : AbstractValidator<SensorGetOneQuery>
{
    public SensorGetOneCommandValidator()
    {
        RuleFor(x => x.Sensor_Id)
            .NotEmpty().WithMessage("Sensor_Id is required.");
    }
}