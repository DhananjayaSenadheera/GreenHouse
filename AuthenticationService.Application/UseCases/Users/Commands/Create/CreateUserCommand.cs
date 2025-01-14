using AuthenticationService.Application.Helpers;
using MediatR;

namespace AuthenticationService.Application.UseCases.Users.Commands.Create;

public class CreateUserCommand : IRequest<TaskStatus>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
}