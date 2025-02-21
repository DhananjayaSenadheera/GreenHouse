using AuthenticationService.Application.Interfaces;
using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases.LoginUser;

public class LoginUserUseCase
{
    private readonly IUserRepository _userRepository; 
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginUserUseCase(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginUserResponse> ExecuteAsync(LoginUserRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user == null)
        {
            return new LoginUserResponse
            {
                Message = "Invalid email or password"
            };
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return new LoginUserResponse
            {
                Message = "Invalid email or password"
            };
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new LoginUserResponse
        {
            Token = token,
            Message = "Logged in"
        };
    }
}