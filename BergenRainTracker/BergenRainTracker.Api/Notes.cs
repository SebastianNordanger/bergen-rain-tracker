// Progress:
// Phase 1:
// Created ASP.NET Core Web API project (.NET 10), set up Git with feature branches, PostgreSQL in Docker via Docker Compose, defined DailyRain class (Id, Date, Millimeters, RainHours), installed EF Core + Npgsql packages, added the connection string,
// and connected it to the database using EF Core (Npgsql) with a DbContext. Created the DailyRains table with the InitialCreate migration.

// Phase 2:
// Get Bergen rain data from Open-Meteo with HttpClient (registered with Dependency Injection, async with GetFromJsonAsync), OpenMeteoResponse class that matches the JSON, save the data to Postgres with RainDbContext (skips days already saved),
// API endpoints in RainController (POST to fetch + save, GET to read), and Swagger UI for testing endpoints in the browser.

// Phase 3 (Last phase):
// Installed Node.js, created the React frontend with Vite (BergenRainTracker.Web, next to the API), replaced the demo page with a "Bergen Rain Tracker" heading,
// added CORS (Cross-Origin Resource Sharing) in Program.cs so React (port 5173) can call the API, React gets the rain data from GET /api/rain with fetch in useEffect (checked in the browser console with F12),
// saved the rain data with useState in App, made a RainTable component file that shows it in a table (App sends rainDays to it as a prop (property) called days), changed the browser tab title and icon (rain emoji) in index.html,
// installed the Recharts package and made a RainChart component file that shows the rain (mm) for each date in a bar chart under the table (gets rainDays as days, same as RainTable),
// added a "Fetch new rain data" button in App (POST to fetch + save, then GET to update the table and chart, disabled while working so it can't be clicked twice), made Date unique in the database with the AddUniqueDateIndex migration,
// replaced the demo CSS with my own styling in index.css (centered page, bigger heading, blue button with gray disabled look, and table with a header line and zebra rows), moved the chart above the table, added a line about the data (historical, not live) and
// the Open-Meteo credit, styled the chart (dark tooltip, "mm" and "Date" on the axes, shorter dates, and width that fits the page with ResponsiveContainer), and removed unused Vite demo files.


// OOP pillars (Encapsulation -> Inheritance -> Abstraction -> Polymorphism):
// Phase 1:
// Encapsulation -> DailyRain.Id has private set, so only EF Core/the database can set it, not outside code
// Inheritance -> RainDbContext inherits from DbContext

// Phase 2:
// Abstraction -> RainController uses Ok() and ToListAsync() without knowing how they work inside

// Phase 3 (Last phase):
// Polymorphism -> RainDbContext overrides OnModelCreating from DbContext to add its own rule (unique Date)


// Git commands used (terminal, ordered by typical workflow):
// git status -> shows what's ready to save, and what's not yet included
// git branch -> lists all branches, the current one is marked with a star (*)
// git log --oneline -3 -> shows the last 3 commits, one line each
// git switch <branch-name> -> switches to another branch
// git checkout -b <branch-name> -> creates a new branch and switches to it right away
// git switch -c <branch-name> -> creates a new branch and switches to it (newer command, same as checkout -b)
// git add . -> marks files as ready to be saved
// git add <file> -> marks only one specific file as ready to be saved
// git rm <file> -> deletes a file and marks the deletion as ready to be saved
// git rm -r <folder> -> deletes a whole folder and everything in it, and marks the deletion as ready to be saved
// git diff <file> -> shows changes not yet marked as ready to be saved (q to exit if it fills the screen)
// git diff --staged <file> -> shows exactly what will be committed for that file (q to exit if it fills the screen)
// git commit -m "<message>" -> saves the marked files, with a short message describing what changed
// git commit --amend --no-edit -> adds new changes into the previous commit instead of making a new one (only safe if not pushed yet)
// git commit --amend -m "<message>" -> fixes the last commit message (only if not pushed yet)
// git push --force-with-lease -> uploads the fixed commit if it was already pushed (only on my branches, never main)
// git push -u origin <branch-name> -> first push of a new branch, also creates it on GitHub
// git push -> uploads commits to GitHub
// git pull -> downloads the latest changes from GitHub
// git merge <branch-name> -> brings a branch's commits into the current branch (e.g. feature into main)


// Docker commands used (PostgreSQL only, API runs in Visual Studio):
// docker compose up -d -> starts the database container in the background
// docker ps -> lists running containers
// docker exec -it bergen-rain-db psql -U rainuser -d raintracker -c "\dt" -> lists the tables in Postgres
// docker exec -it bergen-rain-db psql -U rainuser -d raintracker -> opens Postgres inside the container (\q to exit)
// docker compose down -> stops and removes the container (data is kept in the volume)


// Docker notes:
// Only the database runs in Docker, the API reaches it via localhost:5432.
// The volume (rain-data) keeps the database data even if the container is removed.
// Port is bound to 127.0.0.1, so the database is only reachable from this PC.
// docker-compose.yml is in the top folder (bergen-rain-tracker), but docker compose commands also work from BergenRainTracker, since Docker looks in the folders above.


// EF Core setup (Package Manager Console):
// Packages (installed with: dotnet add package <name>):
// Npgsql.EntityFrameworkCore.PostgreSQL -> lets EF Core talk to Postgres
// Microsoft.EntityFrameworkCore.Design -> needed to create migrations
// Microsoft.EntityFrameworkCore.Tools -> migration commands in Visual Studio
// Connection string is in appsettings.json - tells the API where the database is and how to log in
// Add-Migration InitialCreate -> creates the migration files (Up = create table, Down = undo)
// Update-Database -> applies the migrations to Postgres (first time: created the DailyRains table, and a "fail" is normal since EF Core looks for its list of applied migrations before it exists, then creates it)
// Add-Migration AddUniqueDateIndex -> creates the migration for a unique rule on Date (no two rows with the same date), then the Update-Database command adds it to Postgres


// SQL commands used (PostgreSQL):
// SELECT SUM("Millimeters") FROM "DailyRains"; -> adds up all the rain (quotes needed because EF Core uses capital letters in names, and Postgres makes names lowercase without quotes)
// SELECT COUNT(*) FROM "DailyRains"; -> counts the rows in the table
// DELETE FROM "DailyRains" a USING "DailyRains" b WHERE a."Date" = b."Date" AND a."Id" > b."Id"; -> deletes double rows with the same date, keeps the first one (lowest Id)
// ...


// Open-Meteo notes:
// Free weather API, no key needed: https://open-meteo.com
// Bergen coordinates: 60.39, 5.32 (from Google Maps, rounded to 2 decimals).
// Uses daily time -> Date, precipitation_sum (rain + showers) -> Millimeters, precipitation_hours -> RainHours (Id is set by the database).
// past_days=31&forecast_days=0 -> only finished days (today's value isn't final yet).
// Days go from midnight to midnight (weather model), so they can differ a bit from station data on Yr (yr.no), which seems to count from morning to morning.
// Data is for a small area around Bergen sentrum (a few km wide), not all of Bergen.


// API testing:
// Swagger UI (/swagger) for testing endpoints in the browser (https://localhost:7196/swagger).
// Browser console (F12) on the React page shows what React gets from the API with console.log in the code.
// Network tab (F12 -> Network -> Fetch/XHR) shows the API calls React makes and the data it gets back (click a request -> Preview), works without console.log.
// The React page itself shows the rain data in a table and a bar chart, a quick way to check that the API works (only the table's column titles show if the API is off).


// Endpoints:
// POST /api/rain/fetch -> saves new rain days from Open-Meteo to the database
// GET /api/rain -> returns all saved rain days


// React and terminal commands used (npm, written as npm.cmd since PowerShell blocks npm's script file by default):
// npm.cmd create vite@latest BergenRainTracker.Web -- --template react -> creates the React project with Vite
// cd BergenRainTracker.Web -> moves the terminal into the React folder
// cd .. -> moves the terminal up one folder (e.g. from the React folder back to BergenRainTracker, where docker compose commands work)
// npm.cmd install -> downloads the packages React needs into node_modules (not on GitHub since it's too big, others get it themselves by running npm install, which reads the package list in package.json)
// npm.cmd run dev -> starts the React page on http://localhost:5173/ (q + Enter, or Ctrl+C then Y to stop)
