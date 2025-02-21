using FluentValidation;
using SensorDataService.Application.Requests.GreenHouses.Quaries.Get;
using SensorDataService.Application.Requests.GreenHouses.Quaries.Get.ById;

namespace SensorDataService.Application.Requests.GreenHouses.Validators;

public class GreenHouseGetOneQueryValidator : AbstractValidator<GreenHouseGetOneQuery>
{
    public GreenHouseGetOneQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull().WithMessage("Id is required");
    }
}