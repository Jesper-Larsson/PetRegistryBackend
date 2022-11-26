using Microsoft.AspNetCore.Mvc;

namespace PetRegistryBackend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PetRegistryController: ControllerBase {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PetRegistryController> _logger;

        public PetRegistryController(ILogger<PetRegistryController> logger) {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get() {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("postTest")]
        public IEnumerable<WeatherForecast> test() {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
.ToArray();
        }
    }
}