## Purpose
Make small, precise code changes, follow repository conventions, and prefer edits that keep the solution buildable and testable locally.

## Big picture (what this repo is)
- Monorepo for a .NET 9 solution `BM-Management.sln` with projects:
	- `BM-Management.API` — ASP.NET minimal API + controllers (entrypoint: `Program.cs`). Uses `AddOpenApi()` and maps controllers in development.
	- `BM-Mangement.Domain` — domain models and aggregate roots (example: `AggregateRoots/BManagementRoot/Building.cs` extends `Core.Domain.EntityBase`).
	- `BM-Management.Application`, `BM-Management.Infrastructure` — application and infra layers (standard layered architecture).
	- `core/Core` — shared domain base types (eg `EntityBase`).

## Primary patterns and conventions
- Layered DDD-style layout: Domain models in `BM-Mangement.Domain/AggregateRoots/*`; Application and Infrastructure projects contain services and data access.
- API uses minimal hosting in `BM-Management.API/Program.cs`. Register services in `Program.cs` before `builder.Build()`.
- DTOs and domain entities live in the domain project; prefer mapping in the Application layer rather than modifying domain types for transport concerns.
- Small naming conventions: `BuildingCode`, `Image_Url` (snake-ish in a few properties) — preserve existing property names when touching models to avoid breaking consumers.

## Build / run / debug (developer workflows)
- Use the solution file in root. Typical commands (PowerShell/Windows):

```powershell
dotnet restore BM-Management.sln
dotnet build BM-Management.sln -c Debug
dotnet run --project BM-Management.API --configuration Debug
```

- API exposes OpenAPI in Development via `AddOpenApi()` / `MapOpenApi()` — run with LaunchProfile or `ASPNETCORE_ENVIRONMENT=Development` to see Swagger.

## Tests and verification
- There are no explicit test projects visible; when adding behavior, add a small unit test project (xUnit) parallel to `BM-Management.Application` and wire-up minimal tests for new public behavior.

## Integration points & external deps
- No external services configured in `appsettings.json` in repository snapshot. If you add configuration-driven services, add keys to `appsettings.Development.json` and document expected env vars.

## How to make safe edits
1. Make minimal, focused changes in a single project when possible.
2. Prefer changes to `BM-Management.Application` for behavior changes, and `BM-Management.Infrastructure` for persistence wiring.
3. Keep `BM-Management.API/Program.cs` wiring intact — add service registrations before `builder.Build()`.
4. Preserve public surface area of domain entities (avoid renaming properties) unless performing a coordinated migration across projects.

## Examples from the codebase
- Controller wiring: `BM-Management.API/Controllers/WeatherForecastController.cs` shows the pattern for controllers and DI of `ILogger<T>`.
- Domain entity example: `BM-Mangement.Domain/AggregateRoots/BManagementRoot/Building.cs` — uses data annotations (`[Required]`, `[MaxLength]`) on domain properties.

## Quick heuristics for PRs from AI agents
- Keep PRs atomic: single responsibility, include build+compile verification locally.
- When adding new services, update `Program.cs` and `BM-Management.API/Properties/launchSettings.json` if a new profile is needed.
- If touching database or persistence, add a brief migration plan in the PR description.

## Useful nearby guidance
- This repo contains several `.github/instructions/*.instructions.md` files (C#, ASP.NET, SQL) and `.github/prompts/*` used for common tasks — consult them for domain-specific templates before generating large changes.

If any area above is unclear or you want me to expand examples (service registration, adding a repository, or wiring AutoMapper), tell me which area to expand and I will iterate.
