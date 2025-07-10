
namespace WeatherApp.RestApi.UsingBackgroundService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecastDto> Get()
    {
        try
        {
            return WeatherService.GetWeatherInfo();
        }
        catch (Exception ex)
        {
            logger.LogError("Error occured: {ErrorMessage} ", ex.Message);
            throw;
        }
    }   
}


