using DataAnalysingService.Application.Requests.GreenHouses.Quaries.Get.ById;
using FluentValidation;

namespace DataAnalysingService.Application.Requests.GreenHouses.Validators;

public class GreenHouseGetOneQueryValidator : AbstractValidator<GreenHouseGetOneQuery>
{
    public GreenHouseGetOneQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull().WithMessage("Id is required");
    }
}