
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
        try
        {
            string testEmailPiiRedacted = "vishwa.kumar@slchq.com";
            logger.Info(LogType.Application, "Method: {Method}, Email: {Email} - Get Weather Info", Request.Method, testEmailPiiRedacted);

            var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            logger.Info(LogType.Transaction, "Method: {Method}, Email: {Email}  - Response Body: {@Response}", Request.Method, testEmailPiiRedacted, response);

            return response;
        }
        catch (Exception ex)
        {
            logger.Error(LogType.Application, ex, "Method: {Method} - Error occurred: {ErrorMessage}", Request.Method, ex.Message);
            throw;
        }
    }
}

