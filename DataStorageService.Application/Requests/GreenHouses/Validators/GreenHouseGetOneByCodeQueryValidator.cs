using DataStorageService.Application.Requests.GreenHouses.Quaries.Get.ByCode;
using FluentValidation;

namespace DataStorageService.Application.Requests.GreenHouses.Validators;

public class GreenHouseGetOneByCodeQueryValidator : AbstractValidator<GreenHouseGetOneByCodeQuery>
{
    public GreenHouseGetOneByCodeQueryValidator()
    {
        RuleFor(request => request.Code)
            .NotEmpty().WithMessage("Code is required");
    }
}