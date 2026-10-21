// What to do next session (1 hour ish):
// 1. git status (should be on main, clean). No Docker needed for setup.
// 2. Create a new branch for Phase 3 (feature/react-frontend).
// 3. Create the React project = the frontend (web page with table + bar chart). Install Node.js first if needed. Made with a command, in its own folder next to the API.
// 4. Commit and push.


// Progress:
// Phase 1 (Done):
// Created ASP.NET Core Web API project (.NET 10), set up Git with feature branches, PostgreSQL in Docker via Docker Compose, defined DailyRain class (Id, Date, Millimeters, RainHours), installed EF Core + Npgsql packages, added the connection string,
// and connected it to the database using EF Core (Npgsql) with a DbContext. Created the DailyRains table with the InitialCreate migration.

// Phase 2 (Done):
// Get Bergen rain data from Open-Meteo with HttpClient (registered with Dependency Injection, async with GetFromJsonAsync), OpenMeteoResponse class that matches the JSON, save the data to Postgres with RainDbContext (skips days already saved),
// API endpoints in RainController (POST to fetch + save, GET to read), and Swagger UI for testing endpoints in the browser.

// Phase 3 (Current):
// ...


// OOP pillars (Encapsulation -> Inheritance -> ...):
// Phase 1:
// Encapsulation -> DailyRain.Id has private set, so only EF Core/the database can set it, not outside code
// Inheritance -> RainDbContext inherits from DbContext

// Phase 2:
// Abstraction -> RainController uses Ok() and ToListAsync() without knowing how they work inside

// Phase 3 (Current):
// ...


// Git commands used (terminal, ordered by typical workflow):
// git status -> shows what's ready to save, and what's not yet included
// git log --oneline -3 -> shows the last 3 commits, one line each
// git switch <branch-name> -> switches to another branch
// git checkout -b <branch-name> -> creates a new branch and switches to it right away
// git switch -c <branch-name> -> creates a new branch and switches to it (newer command, same as checkout -b)
// git add . -> marks files as ready to be saved
// git add <file> -> marks only one specific file as ready to be saved
// git commit -m "<message>" -> saves the marked files, with a short message describing what changed
// git commit --amend --no-edit -> adds new changes into the previous commit instead of making a new one (only safe if not pushed yet)
// git commit --amend -m "<message>" -> fixes the last commit message (only if not pushed yet)
// git push --force-with-lease -> uploads the fixed commit if it was already pushed (only on my branches, never main)
// git push -u origin <branch-name> -> first push of a new branch, also creates it on GitHub
// git push -> uploads commits to GitHub
// git pull -> downloads the latest changes from GitHub
// git merge <branch-name> -> brings a branch's commits into the current branch (e.g. feature into main)
// ...


// Docker commands used (PostgreSQL only, API runs in Visual Studio):
// docker compose up -d -> starts the database container in the background
// docker ps -> lists running containers
// docker exec -it bergen-rain-db psql -U rainuser -d raintracker -c "\dt" -> lists the tables in Postgres
// docker exec -it bergen-rain-db psql -U rainuser -d raintracker -> opens Postgres inside the container (\q to exit)
// docker compose down -> stops and removes the container (data is kept in the volume)
// ...

// Docker notes:
// Only the database runs in Docker, the API reaches it via localhost:5432.
// The volume (rain-data) keeps the database data even if the container is removed.
// Port is bound to 127.0.0.1, so the database is only reachable from this PC.
// ...


// EF Core setup (Package Manager Console):
// Packages (installed with: dotnet add package <name>):
// Npgsql.EntityFrameworkCore.PostgreSQL -> lets EF Core talk to Postgres
// Microsoft.EntityFrameworkCore.Design -> needed to create migrations
// Microsoft.EntityFrameworkCore.Tools -> migration commands in Visual Studio
// Connection string is in appsettings.json - tells the API where the database is and how to log in
// Add-Migration InitialCreate -> creates the migration files (Up = create table, Down = undo)
// Update-Database -> creates the table in Postgres (first "fail" is normal, EF Core creates its history table first)
// ...


// SQL commands used (PostgreSQL):
// SELECT SUM("Millimeters") FROM "DailyRains"; -> adds up all the rain (quotes needed because EF Core uses capital letters in names, and Postgres makes names lowercase without quotes)
// ...


// Open-Meteo notes:
// Free weather API, no key needed: https://open-meteo.com
// Bergen coordinates: 60.39, 5.32 (from Google Maps, rounded to 2 decimals).
// Uses daily time -> Date, precipitation_sum (rain + showers) -> Millimeters, precipitation_hours -> RainHours (Id is set by the database).
// past_days=31&forecast_days=0 -> only finished days (today's value isn't final yet).
// Days go from midnight to midnight (weather model), so they can differ a bit from station data on Yr (yr.no), which seems to count from morning to morning.
// ...


// API testing:
// Swagger UI (/swagger) for testing endpoints in the browser (https://localhost:7196/swagger).
// ...


// Endpoints:
// POST /api/rain/fetch -> saves new rain days from Open-Meteo to the database
// GET /api/rain -> returns all saved rain days
// ...


// React commands used (npm):
// ...
