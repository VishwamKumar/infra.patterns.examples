
namespace WeatherApp.RestApi.RedisCache.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IRedisCacheService redisCacheService,
    ILogger<WeatherForecastController> logger) : ControllerBase
{  
    [HttpGet("{city}")]
    public async Task<GetWeatherForecastResponse> Get(string city)
    {
        var cacheKey = $"weather-{city}";
        var cachedWeather = await redisCacheService.GetAsync<GetWeatherForecastResponse>(cacheKey);

        if (cachedWeather!=null)
        {
            return cachedWeather;
        }

        // Simulate fetching weather data from an external service
        IEnumerable<WeatherForecast> weatherForecastData= GetWeatherForecastData();
        GetWeatherForecastResponse weatherForecastRespData = new()
                        {
                            City = city,
                            ForecastTime = DateTime.Now,
                            WeatherForecasts = weatherForecastData
                        };
           
        // Cache the weather data
        await redisCacheService.SetAsync(cacheKey, weatherForecastRespData, TimeSpan.FromMinutes(10));
        
        return weatherForecastRespData;
    }

    private WeatherForecast[] GetWeatherForecastData()
    {
        try
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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

