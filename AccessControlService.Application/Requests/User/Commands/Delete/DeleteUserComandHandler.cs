using AccessControlService.Domain.Interfaces;
using MediatR;

namespace AccessControlService.Application.Requests.User.Commands.Delete;

public class DeleteUserComandHandler : IRequestHandler<DeleteUserComand,bool>
{
    private readonly IUserRepository _userRepository;
    public DeleteUserComandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> Handle(DeleteUserComand comand, CancellationToken cancellationToken)
    {
       //check user exists
       var exUser = _userRepository.GetUserByIdAsync(comand.Id).Result;
       if (exUser == null)
       {
           //throw new Exception($"User with id {comand.Id} not found");
           return false;
       }
       
       await _userRepository.DeleteUserAsync(exUser);
       return true;
    }
}