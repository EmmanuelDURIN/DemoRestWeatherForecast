using DemoWeatherForeCast;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRestRentACar.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    private static List<WeatherForecast> weatherForecasts;
    static WeatherForecastController()
    {
      var rng = new Random();
      weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Id = index,
        Place="Pommiers",
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToList();
    }

    private readonly IConfiguration _configuration;
    private readonly ILogger<WeatherForecastController> _logger;
    public WeatherForecastController(WeatherForecastContext context,
      ILogger<WeatherForecastController> logger,
      IConfiguration configuration)
    {
      _configuration = configuration;
      _logger = logger;
    }
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      return weatherForecasts;
    }
    [HttpGet("{id}")]
    public ActionResult<WeatherForecast> Get(int id)
    {
      var weatherForecast = weatherForecasts.FirstOrDefault( w => w.Id == id);
      if (weatherForecast == null)
        return NotFound();
      else
        return Ok(weatherForecast);
    }
    [HttpPost]
    public ActionResult Post(WeatherForecast weatherForecast)
    {
      if (!ModelState.IsValid)
        return ValidationProblem(ModelState);
      weatherForecasts.Add(weatherForecast);
      weatherForecast.Id = weatherForecasts.Max(x => x.Id)+1;
      return CreatedAtRoute(
          new { controller = nameof(WeatherForecast), action=nameof(Post),
              id = weatherForecast.Id
              },
          weatherForecast
        );
      //return Ok(weatherForecast);
    }
  }
}
