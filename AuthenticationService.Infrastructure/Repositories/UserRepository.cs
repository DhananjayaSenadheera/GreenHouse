using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{

    private readonly DbContext _dbContext;
    
    public UserRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddUserAsync(User user)
    {
        await _dbContext.Set<User>().AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}