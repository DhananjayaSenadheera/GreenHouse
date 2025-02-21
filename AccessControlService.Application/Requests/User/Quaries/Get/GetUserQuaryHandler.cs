using AccessControlService.Application.Requests.User.DTOs;
using AccessControlService.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AccessControlService.Application.Requests.User.Quaries.Get;

public class GetUserQuaryHandler : IRequestHandler<GetUserQuary,GetUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public GetUserQuaryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<GetUserDto> Handle(GetUserQuary quary, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(quary.Id);
        if (user == null)
        {
            return null;
        }
        return _mapper.Map<GetUserDto>(user);
    }
}