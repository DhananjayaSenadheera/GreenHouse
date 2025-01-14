using AuthenticationService.Application.Helpers;
using AuthenticationService.Application.UseCases.Users.Mappers;
using AuthenticationService.Domain.Interfaces;
using MediatR;

namespace AuthenticationService.Application.UseCases.Users.Commands.Create;

public class CreateUserCommandHandler(IUserRepository userRepository, PasswordEncryptionHelper passwordEncryptionHelper)
    : IRequestHandler<CreateUserCommand, TaskStatus>
{
    public async Task<TaskStatus> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        try
        {
            var mapper = new UserMapper();
            var user = mapper.MapCreateUserCommandtoUser(createUserCommand);
            var result = userRepository.AddUserAsync(user);
            return result.Status;
        }
        catch (Exception ex)
        {
            return TaskStatus.Faulted;
        }
        
        
        
    }
}