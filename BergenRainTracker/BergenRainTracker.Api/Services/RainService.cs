using BergenRainTracker.Api.Data;
using BergenRainTracker.Api.Models;

namespace BergenRainTracker.Api.Services;

// Gets Bergen rain data from Open-Meteo and saves it to the database
public class RainService
{
    private readonly HttpClient _httpClient;
    private readonly RainDbContext _context;

    // Dependency Injection (DI) gives RainService an HttpClient (to get data) and a RainDbContext called context (to save it)
    public RainService(HttpClient httpClient, RainDbContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }

    // Calls Open-Meteo and turns the JSON into an OpenMeteoResponse
    public async Task<OpenMeteoResponse> GetBergenRainAsync()
    {
        // Daily rain (mm + hours) in Bergen, last 31 days
        string url = "https://api.open-meteo.com/v1/forecast?latitude=60.39&longitude=5.32&daily=precipitation_sum,precipitation_hours&timezone=Europe%2FOslo&past_days=31&forecast_days=0";

        var response = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(url);

        return response ?? new OpenMeteoResponse();
    }

    // Gets the rain data from Open-Meteo and saves it to the database
    public async Task SaveBergenRainAsync()
    {
        var response = await GetBergenRainAsync();

        var rainDays = new List<DailyRain>();

        for (int i = 0; i < response.Daily.Time.Count; i++)
        {
            var day = new DailyRain
            {
                Date = response.Daily.Time[i],
                Millimeters = response.Daily.PrecipitationSum[i] ?? 0,
                RainHours = response.Daily.PrecipitationHours[i] ?? 0
            };

            rainDays.Add(day);
        }

        _context.DailyRains.AddRange(rainDays);
        await _context.SaveChangesAsync();
    }
}
