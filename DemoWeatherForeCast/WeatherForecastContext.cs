using DemoRestRentACar;
using Microsoft.EntityFrameworkCore;

namespace DemoWeatherForeCast
{
  public class WeatherForecastContext : DbContext
  {
    public WeatherForecastContext()
    {
    }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  base.OnConfiguring(optionsBuilder);
    //  optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=WeatherDb;Integrated Security=True");
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<WeatherForecast>()
          //.HasKey(c => new { c.State, c.LicensePlate });
          .HasIndex(w => w.Place);
    }
  }
}
