using FluentValidation;
using SensorDataService.Application.Requests.Sensors.Commands.Create;

namespace SensorDataService.Application.Requests.Sensors.Validators;

public class SensorCreateCommandValidator : AbstractValidator<SensorCreateCommand>
{
    public SensorCreateCommandValidator()
    {

        RuleFor(x => x.SensorCreateDto.GreenHouse_Id)
            .NotEmpty().WithMessage("GreenHouse Id is required.")
            .NotNull().WithMessage("GreenHouse Id is required.");
    }
}