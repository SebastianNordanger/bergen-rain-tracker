// Progress:
// Phase 1:
// Created ASP.NET Core Web API project (.NET 10), set up Git with feature branches, PostgreSQL in Docker via Docker Compose, defined DailyRain class (id, date, millimeters), and connected it to the database using EF Core (Npgsql) with a DbContext.

// Phase 2:
// ...

// Phase 3 (Last phase):
// ...


// OOP pillars (... -> ...):
// Phase 1:
// ...

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
// ...


// Docker notes:
// Only the database runs in Docker, the API reaches it via localhost:5432.
// The volume (rain-data) keeps the database data even if the container is removed.
// ...


// EF Core setup (Package Manager Console):
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
