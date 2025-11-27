using Microsoft.AspNetCore.Mvc;

namespace DiLifetimesDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] ProductCategories = new[]
{
    "Electrónicos", "Hogar", "Ropa", "Deportes", "Libros",
    "Juguetes", "Belleza", "Alimentos", "Automotriz", "Salud"
};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = ProductCategories[Random.Shared.Next(ProductCategories.Length)]
            })
            .ToArray();
        }
    }
}
