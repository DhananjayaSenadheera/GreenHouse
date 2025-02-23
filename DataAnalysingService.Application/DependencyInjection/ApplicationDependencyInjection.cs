using DataAnalysingService.Application.Behaviors;
using DataAnalysingService.Application.Mappings;
using DataAnalysingService.Application.Requests.GreenHouses.Validators;
using DataAnalysingService.Application.Requests.Sensors.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DataAnalysingService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        
        //GreenHouse
        services.AddValidatorsFromAssemblyContaining<GreenHouseGetOneQueryValidator>(); 
        services.AddValidatorsFromAssemblyContaining<GreenHouseGetOneByCodeQueryValidator>();
        
        //Sensor
        services.AddValidatorsFromAssemblyContaining<SensorGetOneQueryValidator>();
        
        //Other
        services.AddAutoMapper(typeof(ProfileMapper));
  
        return services;
    }
}