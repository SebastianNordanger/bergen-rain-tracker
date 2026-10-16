// Progress:
// Phase 1 (Done):
// Created ASP.NET Core Web API project (.NET 10), set up Git with feature branches, PostgreSQL in Docker via Docker Compose, defined DailyRain class (Id, Date, Millimeters, RainHours), installed EF Core + Npgsql packages, added the connection string,
// and connected it to the database using EF Core (Npgsql) with a DbContext. Created the DailyRains table with the InitialCreate migration.

// Phase 2 (Current):
// ...

// Phase 3 (Last phase):
// ...


// OOP pillars (Encapsulation -> Inheritance -> ...):
// Phase 1:
// Encapsulation -> DailyRain.Id has private set, so only EF Core/the database can set it, not outside code
// Inheritance -> RainDbContext inherits from DbContext

// Phase 2 (Current):
// ...

// Phase 3 (Last phase):
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
// ...


// Open-Meteo notes:
// Free weather API, no key needed: https://open-meteo.com
// Bergen coordinates: 60.39, 5.32 (from Google maps, rounded).
// Uses daily time -> Date, precipitation_sum (rain + showers) -> Millimeters, precipitation_hours -> RainHours (Id is set by the database).


// API testing (PowerShell):
// ...


// Endpoints:
// ...


// React commands used (npm):
// ...
