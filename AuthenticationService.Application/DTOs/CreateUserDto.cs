namespace AuthenticationService.Application.DTOs;

public class CreateUserDto
{
    public string Email { get; set; }
    public string Password { get; set; } // Plain password for input
    public string Fname { get; set; }
    public string Lname { get; set; }
    public string Role { get; set; }
}