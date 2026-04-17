# ContribuyentesDGII

A .NET6 solution that provides a Razor Pages web frontend and a Web API for managing contributor information (Contribuyentes). This repository contains multiple projects separated by responsibility.

## Projects
- `ContribuyentesDGII.Web` — Razor Pages web application (frontend)
- `ContribuyentesDGII.Api` — ASP.NET Core Web API
- `ContribuyentesDGII.Core` — Core domain and business logic
- `ContribuyentesDGII.Data` — Data access layer (repositories, EF Core models)
- `ContribuyentesDGII.Tests` — Unit and integration tests

## Requirements
- .NET6 SDK
- (Optional) SQL Server / LocalDB or a supported database for development

## Quick start
1. Clone the repository
 ```bash
 git clone https://github.com/Flaviofjr/ContribuyentesDGII.git
 cd ContribuyentesDGII
 ```

2. Restore and build
 ```bash
 dotnet restore
 dotnet build
 ```

3. Configure database connection
- Edit connection strings in `ContribuyentesDGII.Api/appsettings.json` and/or `ContribuyentesDGII.Web/appsettings.json` to point to your database instance.

4. Apply EF Core migrations (from repository root)

- (Optional) Install or update the EF Core CLI tool if you don't have it:
```powershell
dotnet tool install --global dotnet-ef --version7.*
# or update if already installed
dotnet tool update --global dotnet-ef --version7.*
```

- Verify available migrations:
```powershell
dotnet ef migrations list --project ContribuyentesDGII.Data --startup-project ContribuyentesDGII.Web
```

- Apply all pending migrations to the configured database:
```powershell
dotnet ef database update --project ContribuyentesDGII.Data --startup-project ContribuyentesDGII.Web
```

- To apply a specific migration by name:
```powershell
dotnet ef database update <MigrationName> --project ContribuyentesDGII.Data --startup-project ContribuyentesDGII.Web
```

5. Seed test data (optional)

A seed script is included at `ContribuyentesDGII.Data/Scripts/Seed-Test-Data.sql`. Run it against the same database you updated with migrations to populate sample data for testing. Choose one of the following methods depending on your environment:

- Using `sqlcmd` (cross-platform; SQL Server tooling must be installed):

```powershell
# SQL Server (provide server, database and credentials as needed)
sqlcmd -S <server> -d <database> -U <username> -P <password> -i "ContribuyentesDGII.Data\Scripts\Seed-Test-Data.sql"

# LocalDB (Windows)
sqlcmd -S (localdb)\\MSSQLLocalDB -d <database> -i "ContribuyentesDGII.Data\Scripts\Seed-Test-Data.sql"
```

- Using PowerShell with `Invoke-Sqlcmd` (requires SqlServer module):

```powershell
# Example using LocalDB
Install-Module SqlServer -Scope CurrentUser -Force # if needed
Invoke-Sqlcmd -ServerInstance "(localdb)\\MSSQLLocalDB" -Database "<database>" -InputFile "ContribuyentesDGII.Data\Scripts\Seed-Test-Data.sql"

# Example using SQL Server auth
Invoke-Sqlcmd -ServerInstance "<server>" -Database "<database>" -Username "<username>" -Password "<password>" -InputFile "ContribuyentesDGII.Data\Scripts\Seed-Test-Data.sql"
```

- Using SQL Server Management Studio (SSMS) or Azure Data Studio:
1. Open `ContribuyentesDGII.Data/Scripts/Seed-Test-Data.sql` in the editor.
2. Connect to the same database used when applying migrations.
3. Execute the script.

Important
- Ensure the connection string in the Web/API project points to the database where you applied migrations before running the seed script.
- The seed script assumes the tables and schema from the applied migrations already exist.

Notes
- The `--project` option points to the project that contains the migrations (`ContribuyentesDGII.Data`).
- The `--startup-project` option points to the project that contains the application's configuration and the `DbContext` configuration (`ContribuyentesDGII.Web`).
- If your `DbContext` or configuration lives in a different project, adjust the `--project` and `--startup-project` values accordingly.

6. Run the API and Web projects (from solution root)
 ```bash
 dotnet run --project ContribuyentesDGII.Api
 dotnet run --project ContribuyentesDGII.Web
 ```

7. Run tests
 ```bash
 dotnet test ./ContribuyentesDGII.Tests
 ```

## Development notes
- The solution targets `.NET6`.
- The Razor Pages site is implemented under `ContribuyentesDGII.Web` — prioritize this project for UI changes.
- Business logic and domain models live in `ContribuyentesDGII.Core` and data access under `ContribuyentesDGII.Data`.

## Contributing
Contributions are welcome! Feel free to open an issue or submit a pull request.
 
1. Fork the project
2. Create your feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a Pull Request
 
##

*Built with ❤️ using C# and .NET Core*
