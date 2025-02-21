namespace AccessControlService.Application.Requests.User.DTOs;

public class GetUserDto
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
}