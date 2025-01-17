using FluentValidation;
using SensorDataService.Application.Requests.GreenHouses.Commands.Delete;

namespace SensorDataService.Application.Requests.GreenHouses.Validators;

public class GreenHouseDeleteCommandValidator : AbstractValidator<GreenHouseDeleteCommand>
{
    public GreenHouseDeleteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}