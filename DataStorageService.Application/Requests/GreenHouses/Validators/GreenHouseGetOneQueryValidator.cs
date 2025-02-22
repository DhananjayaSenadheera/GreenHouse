using DataStorageService.Application.Requests.GreenHouses.Quaries.Get.ById;
using FluentValidation;
using DataStorageService.Application.Requests.GreenHouses.Quaries.Get;

namespace DataStorageService.Application.Requests.GreenHouses.Validators;

public class GreenHouseGetOneQueryValidator : AbstractValidator<GreenHouseGetOneQuery>
{
    public GreenHouseGetOneQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull().WithMessage("Id is required");
    }
}