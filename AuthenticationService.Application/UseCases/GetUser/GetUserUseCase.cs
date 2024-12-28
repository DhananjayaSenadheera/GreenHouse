using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases.GetUser;

public class GetUserUseCase
{
    private readonly IUserRepository _userRepository;
    public GetUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResponse> ExecuteAsync(GetUserRequest request)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            return null;
        }

        return new GetUserResponse
        {
            Email = user.Email,
            Role = user.Role
        };
    }
}