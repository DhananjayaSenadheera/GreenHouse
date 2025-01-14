using AccessControlService.Application.Requests.User.DTos;
using AccessControlService.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AccessControlService.Application.Requests.User.Commands.Update;

public class UpdateUserComandHandler : IRequestHandler<UpdateUserComand , bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UpdateUserComandHandler(IUserRepository repository, IMapper mapper)
    {
        _userRepository = repository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdateUserComand comand, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetUserByIdAsync(comand.Id);
         if (result == null)
         {
             return false;
         }
        var user =  _mapper.Map(comand, result);
        _userRepository.UpdateUserAsync(user);
        return true;
    }
}