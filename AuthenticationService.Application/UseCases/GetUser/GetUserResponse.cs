namespace AuthenticationService.Application.UseCases.GetUser;

public class GetUserResponse
{
    public string Email { get; set; }
    public string Role { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
}