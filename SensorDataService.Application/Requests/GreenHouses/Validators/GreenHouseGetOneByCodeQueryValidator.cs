using FluentValidation;
using SensorDataService.Application.Requests.GreenHouses.Quaries.Get.ByCode;

namespace SensorDataService.Application.Requests.GreenHouses.Validators;

public class GreenHouseGetOneByCodeQueryValidator : AbstractValidator<GreenHouseGetOneByCodeQuery>
{
    public GreenHouseGetOneByCodeQueryValidator()
    {
        RuleFor(request => request.Code)
            .NotEmpty().WithMessage("Code is required");
    }
}