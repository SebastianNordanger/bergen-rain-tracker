using Microsoft.EntityFrameworkCore;
using BergenRainTracker.Api.Data;

// Setup: register services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register RainDbContext so it uses Postgres with the connection string from appsettings.json
builder.Services.AddDbContext<RainDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Run the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
