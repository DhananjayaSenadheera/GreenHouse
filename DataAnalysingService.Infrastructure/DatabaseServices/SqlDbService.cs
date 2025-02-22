using DataAnalysingService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAnalysingService.Infrastructure.DatabaseServices;

public static class SqlDbService
{
    public static IServiceCollection DatabaseService(this IServiceCollection service,IConfiguration configuration)
    {
        service.AddDbContext<DataAnalysingServiceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return service;
    }
}