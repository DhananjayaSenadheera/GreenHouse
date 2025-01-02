namespace AuthenticationService.Application.UseCases.PasswordManager;

public class ResetPasswordRequest
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
}