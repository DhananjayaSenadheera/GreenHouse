using Microsoft.EntityFrameworkCore;
using SensorDataService.Domain.Entities;

namespace SensorDataService.Infrastructure.Configurations;

public class SensorDataServiceDbContext : DbContext
{
   public SensorDataServiceDbContext(DbContextOptions<SensorDataServiceDbContext> options) : base(options){}
   public DbSet<Sensor> Sensors { get; set; }
   public DbSet<Greenhouse> Greenhouses { get; set; }
   public DbSet<SensorReading> SensorReadings { get; set; }
   public DbSet<DefaultSetting> DefaultSettings { get; set; }


   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<DefaultSetting>().HasData(new DefaultSetting
      {
         Id = 1,
         SensorCode = 1,
         SensorPadding = 8,
         SensorPrefix = "SEN",
         GreenHouseCode = 1,
         GreenHousePadding = 8,
         GreenHousePrefix = "GREEN"
      });
   }
}