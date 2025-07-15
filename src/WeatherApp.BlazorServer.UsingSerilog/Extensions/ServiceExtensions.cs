namespace WeatherApp.BlazorServer.UsingSerilog.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRazorServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorComponents()
                        .AddInteractiveServerComponents();
    }
}