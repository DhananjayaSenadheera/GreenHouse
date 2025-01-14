namespace AccessControlService.Application.Requests.User.DTos;

public class GetUserDto
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
}