

namespace WeatherApp.RestApi.UsingSerilog.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogTypeLogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries =
   [
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
   ];

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        logger.Info(LogType.Application, "Method: {Method} - Get Weather Data", Request.Method);

        var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

        logger.Info(LogType.Transaction, "Method: {Method} - Response Body: {@Response}", Request.Method, response);

        return response;
    }
}

