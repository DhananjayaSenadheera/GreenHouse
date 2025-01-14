using AccessControlService.Application.Requests.User.DTos;
using AccessControlService.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AccessControlService.Application.Requests.User.Quaries.List;

public class GetUserListQuaryHandler : IRequestHandler<GetUserListQuary ,List<GetUserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetUserListQuaryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUserDto>> Handle(GetUserListQuary request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetUserListQuaryAsync();
        var list = _mapper.Map<List<GetUserDto>>(result);
        return result != null ? list : null;
    }
}