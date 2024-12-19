using AuthenticationService.Domain.Entities;

namespace AuthenticationService.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
    
}