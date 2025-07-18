﻿namespace WeatherApp.RestApi.UsingSerilog.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    { 
        builder.AddSerilogLogging();
        builder.Services.AddLogTypeLogger();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}