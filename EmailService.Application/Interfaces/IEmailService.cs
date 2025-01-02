using EmailService.Application.UseCases;

namespace EmailService.Application.Interfaces;

public interface IEmailService
{
    Task<SendEmailResponse> SendEmailAsync(SendEmailRequest request);
}