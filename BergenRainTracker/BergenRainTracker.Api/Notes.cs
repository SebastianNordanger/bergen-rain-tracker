// Progress:
// Phase 1:
// Created ASP.NET Core Web API project (.NET 10), set up Git with feature branches, PostgreSQL in Docker via Docker Compose, defined DailyRain class (Id, Date, Millimeters, RainHours), installed EF Core + Npgsql packages, added the connection string,
// and connected it to the database using EF Core (Npgsql) with a DbContext.

// Phase 2:
// ...

// Phase 3 (Last phase):
// ...


// OOP pillars (Encapsulation -> ...):
// Phase 1:
// Encapsulation -> DailyRain.Id has private set, so only EF Core/the database can set it, not outside code

// Phase 2:
// ...

// Phase 3 (Last phase):
// ...


// Phase 1 - Git setup (terminal commands used so far, ordered by typical workflow):
// git status -> shows what's ready to save, and what's not yet included
// git checkout -b <branch-name> -> creates a new branch and switches to it right away
// git add . -> marks files as ready to be saved
// git add <file> -> marks only one specific file as ready to be saved
// git commit -m "<message>" -> saves the marked files, with a short message describing what changed
// git commit --amend --no-edit -> adds new changes into the previous commit instead of making a new one (only safe if not pushed yet)
// git push -u origin <branch-name> -> first push of a new branch, also creates it on GitHub
// git push -> uploads commits to GitHub
// ...


// Phase 1 - Docker commands used (PostgreSQL only, API runs in Visual Studio):
// docker compose up -d -> starts the database container in the background
// docker ps -> lists running containers
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
// ...


// SQL commands used (PostgreSQL):
// ...


// Open-Meteo notes:
// ...


// API testing (PowerShell):
// ...


// Endpoints:
// ...


// Phase 3 - React commands used (npm):
// ...
