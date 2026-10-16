using Microsoft.EntityFrameworkCore;
using BergenRainTracker.Api.Models;

namespace BergenRainTracker.Api.Data
{
    // Database class - inherits from EF Core's DbContext, which handles the connection, saving and tracking changes
    public class RainDbContext : DbContext
    {
        // Constructor - gets the settings (Postgres + connection string) from Program.cs and passes them on to DbContext
        public RainDbContext(DbContextOptions<RainDbContext> options) : base(options)
        {
        }

        // The DailyRains table - each DailyRain object is one row
        public DbSet<DailyRain> DailyRains { get; set; }
    }
}
