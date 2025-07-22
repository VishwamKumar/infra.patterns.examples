
namespace WeatherApp.RestApi.UsingRedisCache.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ICacheService cacheService,
    ILogger<WeatherForecastController> logger) : ControllerBase
{  
    [HttpGet("{city}")]
    public async Task<GetWeatherForecastResponse> Get(string city)
    {
        try
        {
            var cacheKey = $"weather-{city}";
            var cachedWeather = await cacheService.GetAsync<GetWeatherForecastResponse>(cacheKey);

            if (cachedWeather != null)
            {
                return cachedWeather;
            }

            // Simulate fetching weather data from an external service
            IEnumerable<WeatherForecast> weatherForecastData = GetWeatherForecastData();
            GetWeatherForecastResponse weatherForecastRespData = new()
            {
                City = city,
                ForecastTime = DateTime.Now,
                WeatherForecasts = weatherForecastData
            };

            // Cache the weather data
            await cacheService.SetAsync(cacheKey, weatherForecastRespData, sliding: TimeSpan.FromMinutes(10));           
            return weatherForecastRespData;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("all")] // GET /api/weatherforecast/all
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var keys = await cacheService.GetKeysAsync("weather-*");

            var results = new List<GetWeatherForecastResponse>();

            foreach (var key in keys)
            {
                var item = await cacheService.GetAsync<GetWeatherForecastResponse>(key);
                if (item != null)
                    results.Add(item);
            }

            return Ok(results);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving keys from Redis");
            return StatusCode(500, "Internal server error");
        }
    }
    private WeatherForecast[] GetWeatherForecastData()
    {
        try
        {
            return [.. Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })];
        }
        catch (Exception ex)
        {
            logger.LogError("Sorry! Error occured: {error}", ex.Message);
            throw;
        }
    }


    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
}

