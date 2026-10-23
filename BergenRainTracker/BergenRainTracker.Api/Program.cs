// What to do next session (1 hour ish):
// 1. git status (should be on feature/react-frontend branch, clean). Start Docker Desktop + docker compose up -d.
// 2. Run the API in Visual Studio and React (npm.cmd run dev), check both work.
// 3. Let the API allow requests from React (CORS = Cross-Origin Resource Sharing, set up here in Program.cs), since they run on different ports.
// 4. Let React get the rain data from GET /api/rain in App.jsx (check if it arrives in the browser console, F12). Commit and push.


using Microsoft.EntityFrameworkCore;
using BergenRainTracker.Api.Data;
using BergenRainTracker.Api.Services;

// Setup: register services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register RainDbContext so it uses Postgres with the connection string from appsettings.json
builder.Services.AddDbContext<RainDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Gives RainService an HttpClient for calling Open-Meteo
builder.Services.AddHttpClient<RainService>();

// Allow React (different port) to call the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});

// Run the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Swagger UI page for testing endpoints in the browser
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
}

app.UseHttpsRedirection();

// Use the CORS rule
app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
