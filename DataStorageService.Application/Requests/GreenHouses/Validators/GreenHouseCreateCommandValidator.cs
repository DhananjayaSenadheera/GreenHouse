using DataStorageService.Application.Requests.GreenHouses.Commands.Create;
using FluentValidation;

namespace DataStorageService.Application.Requests.GreenHouses.Validators;

public class GreenHouseCreateCommandValidator : AbstractValidator<GreenHouseCreateCommand>
{
    public GreenHouseCreateCommandValidator()
    {
        RuleFor(x => x.GreenHouseCreateDto.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

        /*RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(50).WithMessage("Description must not exceed 50 characters");*/

        /*RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(50).WithMessage("Location must not exceed 50 characters");
            */

    }
}