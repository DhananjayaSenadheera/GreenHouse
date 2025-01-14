using System.Runtime.InteropServices.JavaScript;
using FluentValidation;

namespace AccessControlService.API.Middleware;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
                await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            var errors = ex.Errors.Select(err => new
            {
                err.PropertyName,
                err.ErrorMessage
            });

            await context.Response.WriteAsJsonAsync(new { Error = errors });
        }
    }
}