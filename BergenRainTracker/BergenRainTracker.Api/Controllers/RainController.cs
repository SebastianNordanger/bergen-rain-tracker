using BergenRainTracker.Api.Data;
using BergenRainTracker.Api.Models;
using BergenRainTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BergenRainTracker.Api.Controllers;

// API endpoints for Bergen rain data
[ApiController]
[Route("api/[controller]")]
public class RainController : ControllerBase
{
    private readonly RainService _rainService;
    private readonly RainDbContext _context;

    // DI gives the controller RainService (to fetch + save) and RainDbContext (to read)
    public RainController(RainService rainService, RainDbContext context)
    {
        _rainService = rainService;
        _context = context;
    }

    // POST /api/rain/fetch -> saves new rain days from Open-Meteo to the database
    [HttpPost("fetch")]
    public async Task<IActionResult> FetchRain()
    {
        await _rainService.SaveBergenRainAsync();
        return Ok("Rain data saved");
    }

    // GET /api/rain -> returns all saved rain days
    [HttpGet]
    public async Task<ActionResult<List<DailyRain>>> GetRain()
    {
        var days = await _context.DailyRains.ToListAsync();
        return Ok(days);
    }
}
