# Mal — History

## 2026-07-09 — Scaffolded complete dotnet new template structure

Created all project files for the `dotnet new aspire-blazor` template. Placeholder `ProjectName` is the `sourceName` in `template.json` — dotnet new replaces it everywhere on instantiation.

**Files created (37 total):**
- Root: `ProjectName.slnx`, `Directory.Build.props`, `Directory.Packages.props`, `.template.config/template.json`
- `src/ProjectName.AppHost/` — Aspire host with UI project reference
- `src/ProjectName.Domain/` — clean domain library with `AssemblyMarker` and README
- `src/ProjectName.UI/` — Blazor Server with Auth0, full layout/pages/wwwroot
- `tests/ProjectName.Architecture.Tests/` — NetArchTest starter (`LayerTests.cs`)
- `tests/ProjectName.Integration.Tests/` — Aspire.Hosting.Testing starter (`AppHostTests.cs`)
- `tests/ProjectName.Unit.Tests/` — NSubstitute setup
- `tests/ProjectName.Component.Tests/` — bunit setup
- `tests/ProjectName.E2E.Tests/` — Playwright + Aspire.Hosting.Testing setup

**Key decisions:**
- Central package management via `Directory.Packages.props` (no Version attrs in .csproj files)
- xUnit v3 (1.1.0) + Microsoft.Testing.Platform (1.6.3) across all test projects
- Auth0 via `Auth0.AspNetCore.Authentication` 1.4.4 in UI; secrets left as placeholders
- No ServiceDefaults project — kept wiring direct to avoid premature abstraction
- `AssemblyMarker.cs` added to Domain so architecture tests can locate the assembly

## 2026-07-09 — Removed `ProjectName.` prefix from all project directories and .csproj files

Renamed all 8 project directories and their .csproj files, dropping the `ProjectName.` prefix:
- `src/ProjectName.AppHost/` → `src/AppHost/` (AppHost.csproj)
- `src/ProjectName.Domain/` → `src/Domain/` (Domain.csproj)
- `src/ProjectName.UI/` → `src/UI/` (UI.csproj)
- `tests/ProjectName.Architecture.Tests/` → `tests/Architecture.Tests/` (Architecture.Tests.csproj)
- `tests/ProjectName.Integration.Tests/` → `tests/Integration.Tests/` (Integration.Tests.csproj)
- `tests/ProjectName.Unit.Tests/` → `tests/Unit.Tests/` (Unit.Tests.csproj)
- `tests/ProjectName.Component.Tests/` → `tests/Component.Tests/` (Component.Tests.csproj)
- `tests/ProjectName.E2E.Tests/` → `tests/E2E.Tests/` (E2E.Tests.csproj)

Updated `ProjectName.slnx`, all `<ProjectReference>` paths in .csproj files, Aspire generated type names (`Projects.UI`, `Projects.AppHost`), the Blazor stylesheet href, and descriptive strings in README/CSS. Standalone `ProjectName` substitution token in namespaces/type refs intentionally left untouched.

**Requested by:** mpaulosky



Joined the ProjectTemplate crew as Lead / Architect.

**Project:** ProjectTemplate — C# .NET template with Aspire AppHost, Domain library, and Blazor Server UI. Tests live in `tests/` (Architecture, Integration, Unit, BUnit, E2E). Source in `src/` (AppHost, Domain, Blazor).

**Requested by:** mpaulosky

## 2026-07-09 — Scaffolded project template structure

Created 37 files: ProjectName.slnx at root, Directory.Build.props, Directory.Packages.props, .template.config/template.json. Source projects: ProjectName.AppHost (Aspire), ProjectName.Domain, ProjectName.UI (Blazor Server + Auth0). Test projects: Architecture (NetArchTest), Integration (Aspire.Hosting.Testing), Unit (NSubstitute), Component (BUnit), E2E (Playwright). Central package management via Directory.Packages.props. xUnit v3 + Microsoft Testing Platform v2. Requested by mpaulosky.

## 2026-07-09 — Rewrote README.md and updated all docs/ to use ProjectName token

Replaced `MyBlog`-specific README with a proper template README using `ProjectName` as the dotnet new substitution token throughout. Updated five files:
- `README.md` — full rewrite (140 lines): ProjectName token, correct tech stack, accurate project structure, Getting Started with Auth0 setup, 5-tier testing table
- `docs/CONTRIBUTING.md` — replaced old folder tree (Api/Shared/Web) with correct template layout (AppHost/Domain/UI + 5 test projects)
- `docs/REFERENCES.md` — full rewrite: removed AINotesApp/EF Core/SQL Server/MediatR refs; added Aspire, Auth0, xUnit v3, BUnit, NetArchTest, Playwright, CPM references
- `docs/SECURITY.md` — replaced `AINotesApp` with `ProjectName`; updated auth section from ASP.NET Core Identity to Auth0
- `docs/CODE_OF_CONDUCT.md` — no changes (no hardcoded project names)

**Requested by:** mpaulosky

## 2026-07-09 — Updated README and docs for template token substitution

Full rewrite of README.md using `ProjectName` token and `your-github-username` placeholder. Updated docs/CONTRIBUTING.md folder structure. Full rewrite of docs/REFERENCES.md to match actual tech stack. Updated docs/SECURITY.md replacing AINotesApp with ProjectName and updating auth section to Auth0. CODE_OF_CONDUCT.md unchanged. Requested by mpaulosky.

## 2026-07-09 — Added Auth0 template symbols and postActions

Added Auth0Domain and Auth0ClientId parameter symbols to template.json with replaces targeting the appsettings.json placeholders. Added two postActions to run dotnet user-secrets set after template instantiation. Created docs/AUTH0_SETUP.md. Requested by mpaulosky.
