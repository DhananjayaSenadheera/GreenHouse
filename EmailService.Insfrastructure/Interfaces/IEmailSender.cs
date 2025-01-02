using EmailService.Domain.Domain;

namespace EmailService.Insfrastructure.Interfaces;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(Email email);
}