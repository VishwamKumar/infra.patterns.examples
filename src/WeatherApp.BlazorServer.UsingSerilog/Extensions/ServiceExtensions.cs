namespace WeatherApp.BlazorServer.UsingSerilog.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRazorServices(this WebApplicationBuilder builder)
    {
        builder.AddSerilogLogging();
        builder.Services.AddLogTypeLogger(builder.Configuration);
        builder.Services.AddRazorComponents()
                        .AddInteractiveServerComponents();
    }
}