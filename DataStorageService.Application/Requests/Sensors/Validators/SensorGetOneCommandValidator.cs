using DataStorageService.Application.Requests.Sensors.Quaries.GetOne;
using FluentValidation;

namespace DataStorageService.Application.Requests.Sensors.Validators;

public class SensorGetOneCommandValidator : AbstractValidator<SensorGetOneQuery>
{
    public SensorGetOneCommandValidator()
    {
        RuleFor(x => x.Sensor_Id)
            .NotEmpty().WithMessage("Sensor_Id is required.");
    }
}