// What to do next session:
// 1. docker compose up -d and check the branch with git status.
// 2. Save the rain data to the database in RainService (using RainDbContext).
// 3. Make the POST and GET endpoints (RainController) and test them in Swagger if time allows.
// 4. Commit, push, and docker compose down.


using BergenRainTracker.Api.Models;

namespace BergenRainTracker.Api.Services;

// Gets Bergen rain data from Open-Meteo
public class RainService
{
    private readonly HttpClient _httpClient;

    public RainService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
        
    // Calls Open-Meteo and turns the JSON into an OpenMeteoResponse
    public async Task<OpenMeteoResponse> GetBergenRainAsync()
    {
        // Daily rain (mm + hours) in Bergen, last 31 days
        string url = "https://api.open-meteo.com/v1/forecast?latitude=60.39&longitude=5.32&daily=precipitation_sum,precipitation_hours&timezone=Europe%2FOslo&past_days=31&forecast_days=0";

        var response = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(url);

        return response ?? new OpenMeteoResponse();
    }
}
