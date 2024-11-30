using Microsoft.AspNetCore.Mvc;

namespace git_releases_demo_webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "test"
    };

    private const int _maxTempC = 62;
    private const int _minTempC = -55;

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 8).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(_minTempC, _maxTempC),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("larger-set", Name = "Get Large Set Weather Forecast")]
    public IEnumerable<WeatherForecast> GetLargerSet(int page)
    {
        int pageSize = 30;
        return Enumerable.Range(1, 200).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(_minTempC, _maxTempC),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .Skip(pageSize * page - 2)
            .Take(pageSize)
        .ToArray();
    }
}