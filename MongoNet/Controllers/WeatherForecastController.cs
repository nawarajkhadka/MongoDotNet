using Microsoft.AspNetCore.Mvc;
using MongoNet.Contracts.Interfaces.Services;
using MongoNet.Contracts.Models;

namespace MongoNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherForeCastService _weatherForeCastService { get; set; }
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForeCastService  weatherForeCastService, ILogger<WeatherForecastController> logger) {
            _weatherForeCastService = weatherForeCastService;
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

     
    

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Weather>> Get()
        {
            return await _weatherForeCastService.GetAll();
        }

        [HttpPost(Name = "AddWeatherForeCast")]
        public async Task Add(Weather weather)
        {
            await _weatherForeCastService.AddWeatherAsync(weather);
        }
    }
}
