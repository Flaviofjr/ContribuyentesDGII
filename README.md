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
- Edit connection strings in `ContribuyentesDGII.Api/appsettings.json` and/or `ContribuyentesDGII.Web/appsettings.json` to point to your database instance. If the solution uses EF Core migrations, apply them before running.

4. Run the API and Web projects (from solution root)
 ```bash
 dotnet run --project ContribuyentesDGII.Api
 dotnet run --project ContribuyentesDGII.Web
 ```

5. Run tests
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
