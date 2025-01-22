using FluentValidation;
using SensorDataService.Application.Requests.GreenHouses.Quaries.Get;

namespace SensorDataService.Application.Requests.GreenHouses.Validators;

public class GreenHouseGetOneCommandValidator : AbstractValidator<GreenHouseGetOneCommand>
{
    public GreenHouseGetOneCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull().WithMessage("Id is required");
    }
}