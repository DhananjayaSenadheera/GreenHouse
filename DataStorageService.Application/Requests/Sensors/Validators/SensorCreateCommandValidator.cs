using DataStorageService.Application.Requests.Sensors.Commands.Create;
using FluentValidation;

namespace DataStorageService.Application.Requests.Sensors.Validators;

public class SensorCreateCommandValidator : AbstractValidator<SensorCreateCommand>
{
    public SensorCreateCommandValidator()
    {

        RuleFor(x => x.SensorCreateDto.GreenHouse_Id)
            .NotEmpty().WithMessage("GreenHouse Id is required.")
            .NotNull().WithMessage("GreenHouse Id is required.");
    }
}