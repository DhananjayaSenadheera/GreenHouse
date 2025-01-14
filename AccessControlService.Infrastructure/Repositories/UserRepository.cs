using AccessControlService.Domain.Entities;
using AccessControlService.Domain.Interfaces;
using AccessControlService.Infrastructure.Configurations;
using AccessControlService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccessControlService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _databaseContext;
    
    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _databaseContext.Users.FirstAsync(u => u.Email == email);
        return user;
    }

    public async Task<Guid> AddUserAsync(User user)
    {
       await  _databaseContext.Users.AddAsync(user);
       await _databaseContext.SaveChangesAsync();
       var result = typeof(User).GetProperty("Id");
       return (Guid)result.GetValue(user);
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        var user = await _databaseContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
        return user;
    }

    public Guid UpdateUserAsync(User user)
    {
        var result =  _databaseContext.Update(user);
        _databaseContext.SaveChanges();
        return result.Entity.Id;
   
    }
    
    public Task DeleteUserAsync(User user)
    {
        var result = _databaseContext.Users.Remove(user);
        _databaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public async Task<List<User>> GetUserListQuaryAsync()
    {
        var result = await _databaseContext.Users.ToListAsync();
        return result;
    }
}