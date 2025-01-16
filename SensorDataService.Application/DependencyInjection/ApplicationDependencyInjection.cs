using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SensorDataService.Application.Behaviors;
using SensorDataService.Application.Requests.GreenHouses.Mappings;
using SensorDataService.Application.Requests.GreenHouses.Validators;

namespace SensorDataService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationLayers(this IServiceCollection services)
    {
        services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<GreenHouseCreateCommandValidator>(); 
        services.AddAutoMapper(typeof(ProfileMapper));
        return services;
    }
}