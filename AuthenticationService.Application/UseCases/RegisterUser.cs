using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases;

public class RegisterUser
{
    private readonly IUserRepository _userRepository;
    
    public RegisterUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task Execute(string email, string password, string role)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Role = role
        };
        await _userRepository.AddUserAsync(user);
    }
}