namespace EmailService.Application.UseCases;

public class SendEmailResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}