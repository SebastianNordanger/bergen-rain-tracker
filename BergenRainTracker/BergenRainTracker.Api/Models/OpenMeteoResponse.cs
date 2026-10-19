using System.Text.Json.Serialization;

namespace BergenRainTracker.Api.Models;

// Matches the JSON from Open-Meteo
public class OpenMeteoResponse
{
    public DailyData Daily { get; set; } = new();
}

// The daily rain values (one item per day)
public class DailyData
{
    public List<DateOnly> Time { get; set; } = new();

    [JsonPropertyName("precipitation_sum")]
    public List<double?> PrecipitationSum { get; set; } = new();

    [JsonPropertyName("precipitation_hours")]
    public List<double?> PrecipitationHours { get; set; } = new();
}
