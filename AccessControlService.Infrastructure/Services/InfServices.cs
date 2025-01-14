using AccessControlService.Domain.Interfaces;
using AccessControlService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlService.Infrastructure.Services;

public static class InfServices
{
    public static IServiceCollection AddInfServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}