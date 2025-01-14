namespace AccessControlService.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = new Guid();
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
}