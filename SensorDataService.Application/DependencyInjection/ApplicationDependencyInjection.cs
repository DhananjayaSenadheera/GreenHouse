using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SensorDataService.Application.Behaviors;
using SensorDataService.Application.Mappings;
using SensorDataService.Application.Requests.GreenHouses.Validators;
using SensorDataService.Application.Requests.Sonsors.Validators;
using SensorDataService.Application.Settings;

namespace SensorDataService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationLayers(this IServiceCollection services)
    {
        services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<GreenHouseCreateCommandValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseUpdateCommandValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseDeleteCommandValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseGetOneCommandValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseDeleteCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<SensorCreateCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<SensorUpdateCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<SensorGetOneCommandValidator>();
        services.AddTransient<SensorCodeSettings>();
        services.AddAutoMapper(typeof(ProfileMapper));
        return services;
    }
}