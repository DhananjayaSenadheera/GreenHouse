using DataStorageService.Application.Requests.GreenHouses.Commands.Update;
using FluentValidation;

namespace DataStorageService.Application.Requests.GreenHouses.Validators;

public class GreenHouseUpdateCommandValidator : AbstractValidator<GreenHouseUpdateCommand>
{
    public GreenHouseUpdateCommandValidator()
    {
        RuleFor(x => x.GreenHouseUpdateDto.GreenHouse_Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
        
    }
}