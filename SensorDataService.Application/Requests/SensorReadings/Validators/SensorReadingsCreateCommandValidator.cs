using FluentValidation;
using SensorDataService.Application.Requests.SensorReadings.Commands.Create;

namespace SensorDataService.Application.Requests.Sonsors.Validators;

public class SensorReadingsCreateCommandValidator : AbstractValidator<SensorReadingCreateCommand>
{
    public SensorReadingsCreateCommandValidator()
    {
        RuleFor(x => x.DataList)
            .NotEmpty().WithMessage("Data list is required")
            .NotNull().WithMessage("Data list is required");
        RuleFor(x => x.DataList.Count)
            .NotEmpty().WithMessage("Data list is required")
            .NotNull().WithMessage("Data list is required")
            .GreaterThan(0).WithMessage("Data list must be greater than 0");
        
    }
}