using System.Text.RegularExpressions;
using EmailService.Application.Interfaces;
using EmailService.Domain.Domain;
using EmailService.Domain.Interfaces;

namespace EmailService.Application.UseCases;

public class SendEmailUseCase
{
    private readonly IEmailRepository _emailRepository;
    public SendEmailUseCase(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }
    
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"); // Simple email validation pattern
        return emailRegex.IsMatch(email);
    }

    public async Task<SendEmailResponse> ExecuteAsync(SendEmailRequest request)
    {
        if (request.To == null || request.To.Length < 6)
        {
            return new SendEmailResponse{ Message = "To address is required",IsSuccess = false };
        }
        if (!IsValidEmail(request.To) )
        {
            return new SendEmailResponse{ Message = "To address is invalid",IsSuccess = false };
        }

        if (request.Subject == null)
        {
            return new SendEmailResponse{ Message = "Subject is required",IsSuccess = false };
        }

        if (request.Body == null)
        {
            return new SendEmailResponse{ Message = "Body is required",IsSuccess = false };
        }

        var email = new Email
        {
            To = request.To,
            Subject = request.Subject,
            Body = request.Body
        };
         var result =  await _emailRepository.SendEmailAsync(email);
        if(result)
        {
            return new SendEmailResponse{ Message = "Email sent successfully",IsSuccess = true };
        }
        return new SendEmailResponse{ Message = "Email could not be sent",IsSuccess = false };
        
        
    }
}