using MediatR;

namespace AccessControlService.Application.Requests.User.Commands.Create;

public class CreateUserCommand :IRequest<Guid>
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
}