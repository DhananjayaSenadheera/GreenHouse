using DataAnalysingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAnalysingService.Infrastructure.Configurations;

public class DataAnalysingServiceDbContext(DbContextOptions<DataAnalysingServiceDbContext> options) : DbContext(options)
{
   public DbSet<Sensor> Sensors { get; set; }
   public DbSet<Greenhouse> Greenhouses { get; set; }
   public DbSet<SensorReading> SensorReadings { get; set; }
}