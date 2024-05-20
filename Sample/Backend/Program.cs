using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

// <PackageReference Include="Aspire.Hosting.Redis" Version="8.0.0-preview.7.24251.11"/>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (IDistributedCache cache, ILogger<WeatherForecast> logger) =>
    {
        // var cacheData = cache.GetString("weatherforecast");
        // if (cacheData != null)
        // {
        //     logger.LogInformation("Cache hit");
        //     
        //     return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(cacheData);
        // }
        
        // var ran = new Random().Next(0, 5);
        // if (ran == 0)
        // {
        //     throw new Exception("Error");
        // }
        
        
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        
        // cache.SetString("weatherforecast", JsonSerializer.Serialize(forecast), new DistributedCacheEntryOptions
        // {
        //     AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5),
        // });
        
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}