using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces;
using AuthenticationService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{

    private readonly DatabaseContext _dbContext;
    
    public UserRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> AddUserAsync(User user)
    {
        var result = await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return result.Entity; ;
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }

    public async Task UpdateUserAsync(User user)
    {
       _dbContext.Set<User>().Update(user);
       await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {
       _dbContext.Users.Remove(user);
       await _dbContext.SaveChangesAsync();
    }
}