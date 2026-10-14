namespace BergenRainTracker.Api.Models
{
    // Rain data for one day in Bergen
    public class DailyRain
    {
        public int Id { get; private set; } // Set by the database with private set
        public DateOnly Date { get; set; }
        public double Millimeters { get; set; }
        public double RainHours { get; set; }
    }
}
