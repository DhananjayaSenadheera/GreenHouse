using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(co => co.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}