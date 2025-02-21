using FluentValidation;
using MassTransit;
using MassTransit.MultiBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SensorDataService.Application.Behaviors;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Mappings;
using SensorDataService.Application.Requests.GreenHouses.Validators;
using SensorDataService.Application.Requests.SensorReadings.Validators;
using SensorDataService.Application.Requests.Sensors.Validators;
using SensorDataService.Application.Settings;

namespace SensorDataService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationLayers(this IServiceCollection services)
    {
        services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        
        //GreenHouse
        services.AddValidatorsFromAssemblyContaining<GreenHouseCreateCommandValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseUpdateCommandValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseDeleteCommandValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseGetOneQueryValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseDeleteCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<GreenHouseGetOneByCodeQueryValidator>();
        
        //Sensor
        services.AddValidatorsFromAssemblyContaining<SensorCreateCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<SensorUpdateCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<SensorGetOneCommandValidator>();
        
        //Sensor Readings
        services.AddValidatorsFromAssemblyContaining<SensorReadingsCreateCommandValidator>();
        
        //Other
        services.AddTransient<SensorCodeSettings>();
        services.AddTransient<GreenHouseCodeSettings>();
        services.AddAutoMapper(typeof(ProfileMapper));

        
        return services;
    }
}