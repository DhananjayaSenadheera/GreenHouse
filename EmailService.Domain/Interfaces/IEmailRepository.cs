using EmailService.Domain.Domain;

namespace EmailService.Domain.Interfaces;

public interface IEmailRepository
{
    Task<bool> SendEmailAsync(Email email);
}