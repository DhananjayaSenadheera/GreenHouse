using FluentValidation;
using SensorDataService.Application.Requests.GreenHouses.Commands.Update;

namespace SensorDataService.Application.Requests.GreenHouses.Validators;

public class GreenHouseUpdateCommandValidator : AbstractValidator<GreenHouseUpdateCommand>
{
    public GreenHouseUpdateCommandValidator()
    {
        RuleFor(x => x.UpdateDto.GreenHouse_Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
        
    }
}