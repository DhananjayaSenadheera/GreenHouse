using DataStorageService.Application.Requests.GreenHouses.Commands.Delete;
using FluentValidation;

namespace DataStorageService.Application.Requests.GreenHouses.Validators;

public class GreenHouseDeleteCommandValidator : AbstractValidator<GreenHouseDeleteCommand>
{
    public GreenHouseDeleteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}