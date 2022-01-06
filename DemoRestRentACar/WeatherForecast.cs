using System;
using System.ComponentModel.DataAnnotations;

namespace DemoRestRentACar
{
  public class WeatherForecast
  {
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Place{ get; set; }
    public DateTime Date { get; set; }
    [Range(-100, 100)]
    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; set; }

    public int MyProperty { get; set; }
  }
}
