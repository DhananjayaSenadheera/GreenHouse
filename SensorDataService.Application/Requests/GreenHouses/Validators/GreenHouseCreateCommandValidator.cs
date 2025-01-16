using FluentValidation;
using SensorDataService.Application.Requests.GreenHouses.Commands.Create;

namespace SensorDataService.Application.Requests.GreenHouses.Validators;

public class GreenHouseCreateCommandValidator : AbstractValidator<GreenHouseCreateCommand>
{
    public GreenHouseCreateCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(50).WithMessage("Description must not exceed 50 characters");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(50).WithMessage("Location must not exceed 50 characters");

    }
}