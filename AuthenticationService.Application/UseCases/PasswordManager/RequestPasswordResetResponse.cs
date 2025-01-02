namespace AuthenticationService.Application.UseCases.PasswordManager;

public class RequestPasswordResetResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}