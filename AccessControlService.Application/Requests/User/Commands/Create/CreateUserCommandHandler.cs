using AccessControlService.Application.Helper;
using AccessControlService.Application.Requests.User.Mappers;
using AccessControlService.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AccessControlService.Application.Requests.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand , Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordEncryptionHelper _encryptionHelper;
    private readonly IMapper _mapper;
    
    public CreateUserCommandHandler(IUserRepository userRepository, PasswordEncryptionHelper encryptionHelper, IMapper mapper)
    {
        _userRepository = userRepository;
        _encryptionHelper = encryptionHelper;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
       // var mapper = new UserMapper();
       // var user = mapper.MapCreateUsercommandToUser(command);
        var user = _mapper.Map<Domain.Entities.User>(command);
        user.PasswordHash = _encryptionHelper.HashPassword(command.PasswordHash);
        var result = await _userRepository.AddUserAsync(user);
        return result;
    }
    
}