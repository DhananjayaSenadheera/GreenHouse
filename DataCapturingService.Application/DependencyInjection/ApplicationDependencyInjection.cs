using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DataCapturingService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationLayers(this IServiceCollection services)
    {
        services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly));
       // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
       return services;
    }

}