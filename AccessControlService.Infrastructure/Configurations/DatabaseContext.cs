using AccessControlService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccessControlService.Infrastructure.Configurations;

public class DatabaseContext : DbContext
{
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }
    public DbSet<User> Users { get; set; }
}