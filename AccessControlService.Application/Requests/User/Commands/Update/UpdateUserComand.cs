using MediatR;

namespace AccessControlService.Application.Requests.User.Commands.Update;

public class UpdateUserComand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
}