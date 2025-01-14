using AccessControlService.Application.Behaviours;
using AccessControlService.Application.Helper;
using AccessControlService.Application.Requests.User.Mappers;
using AccessControlService.Application.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlService.Application.Services;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    { 
        services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(ApplicationService).Assembly));
        services.AddTransient<PasswordEncryptionHelper>();
        services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<DeleteUserCommandValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}