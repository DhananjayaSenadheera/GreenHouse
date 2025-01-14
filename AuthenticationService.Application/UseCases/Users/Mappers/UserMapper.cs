using AuthenticationService.Application.UseCases.Users.Commands.Create;
using AuthenticationService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace AuthenticationService.Application.UseCases.Users.Mappers;

[Mapper]
public partial class UserMapper
{
   public partial User MapCreateUserCommandtoUser(CreateUserCommand createUserCommand);
}