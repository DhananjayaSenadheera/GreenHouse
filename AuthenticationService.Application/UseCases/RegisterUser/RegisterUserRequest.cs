namespace AuthenticationService.Application.UseCases;

public class RegisterUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}