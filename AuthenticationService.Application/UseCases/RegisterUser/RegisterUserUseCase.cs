using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;

    public RegisterUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<RegisterUserResponse> ExecuteAsync(RegisterUserRequest request)
    {
        var exsistingUser = await _userRepository.GetUserByEmailAsync(request.Email);
        if (exsistingUser != null)
        {
            return new RegisterUserResponse{Message = "User already exists"};
        }
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = hashedPassword,
            Role = request.Role,
        };
        
        await _userRepository.AddUserAsync(user);
        return new RegisterUserResponse{Message = "User registered"};
        
    }
    
}