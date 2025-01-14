using AccessControlService.Domain.Entities;

namespace AccessControlService.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<Guid> AddUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
    Guid UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
    Task<List<User>> GetUserListQuaryAsync();
}