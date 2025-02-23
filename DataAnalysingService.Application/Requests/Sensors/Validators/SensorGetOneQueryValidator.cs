using DataAnalysingService.Application.Requests.Sensors.Quaries.GetOne;
using FluentValidation;

namespace DataAnalysingService.Application.Requests.Sensors.Validators;

public class SensorGetOneQueryValidator : AbstractValidator<SensorGetOneQuery>
{
    public SensorGetOneQueryValidator()
    {
        RuleFor(x => x.Sensor_Id)
            .NotEmpty().WithMessage("Sensor_Id is required.");
    }
}