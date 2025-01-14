using AuthenticationService.Application.Helpers;
using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordEncryptionHelper _passwordEncryptionHelper;
    public RegisterUserUseCase(IUserRepository userRepository, PasswordEncryptionHelper passwordEncryptionHelper)
    {
        _userRepository = userRepository;
        _passwordEncryptionHelper = passwordEncryptionHelper;
    }

    public async Task<RegisterUserResponse> ExecuteAsync(RegisterUserRequest request)
    {
        if (request.Email is null || request.Email.Length < 6)
        {
            return new RegisterUserResponse{Message = "Email address cannot be empty"};
        }

        if (request.Password is null || request.Password.Length < 6)
        {
            return new RegisterUserResponse{Message = "Password cannot be empty"};
        }

        if (request.Fname is null)
        {
            return new RegisterUserResponse{Message = "First name cannot be empty"};
        }

        if (request.Lname is null)
        {
            return new RegisterUserResponse{Message = "Last name cannot be empty"};
        }
        var exsistingUser = await _userRepository.GetUserByEmailAsync(request.Email);
        if (exsistingUser != null)
        {
            return new RegisterUserResponse{Message = "User already exists"};
        }
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = _passwordEncryptionHelper.HashPassword(request.Password),
            Role = request.Role,
            Fname = request.Fname,
            Lname = request.Lname
        };
        
        await _userRepository.AddUserAsync(user);
        return new RegisterUserResponse{Message = "User registered"};
        
    }
    
}