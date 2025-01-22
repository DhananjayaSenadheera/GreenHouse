using FluentValidation;
using SensorDataService.Application.Requests.Sonsors.Quaries.GetOne;

namespace SensorDataService.Application.Requests.Sonsors.Validators;

public class SensorGetOneCommandValidator : AbstractValidator<SensorGetOneCommand>
{
    public SensorGetOneCommandValidator()
    {
        RuleFor(x => x.Sensor_Id)
            .NotEmpty().WithMessage("Sensor_Id is required.");
    }
}