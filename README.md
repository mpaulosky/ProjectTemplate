# ProjectName

A production-ready .NET 10 project template with Aspire orchestration, Blazor Server UI, Auth0 authentication, and a comprehensive five-tier test suite.

[![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![xUnit Tests](https://img.shields.io/badge/Tests-xUnit_v3-blueviolet?logo=github)](https://github.com/your-github-username/ProjectName/actions)
[![Latest Release](https://img.shields.io/github/v/release/your-github-username/ProjectName?logo=github&color=blue&label=Release)](https://github.com/your-github-username/ProjectName/releases/latest)

[![CI/CD](https://github.com/your-github-username/ProjectName/actions/workflows/ci.yml/badge.svg)](https://github.com/your-github-username/ProjectName/actions/workflows/ci.yml)

[![Open Issues](https://img.shields.io/github/issues/your-github-username/ProjectName?color=0366d6)](https://github.com/your-github-username/ProjectName/issues?q=is%3Aopen+is%3Aissue)
[![Open PRs](https://img.shields.io/github/issues-pr/your-github-username/ProjectName?color=28a745)](https://github.com/your-github-username/ProjectName/pulls?q=is%3Aopen+is%3Apr)

## Overview

**ProjectName** is scaffolded from the `aspire-blazor` dotnet new template. It provides clean architecture foundations — Aspire service orchestration, Blazor Server rendering, Auth0 authentication, and a full five-tier test suite — so you can focus on building your domain rather than plumbing.

## Technology Stack

| Layer | Technology |
|---|---|
| Platform | .NET 10 (SDK 10.0.300) |
| Orchestration | .NET Aspire — health checks, OpenTelemetry, service discovery |
| UI | Blazor Server (Interactive Server Rendering) |
| Authentication | Auth0 (`Auth0.AspNetCore.Authentication`) |
| Unit testing | xUnit v3 + Microsoft Testing Platform v2 |
| Assertions | FluentAssertions |
| Mocking | NSubstitute |
| Component tests | BUnit |
| Architecture tests | NetArchTest.Rules |
| E2E tests | Playwright |
| Package management | Central Package Management (`Directory.Packages.props`) |
| Database / ORM | _Bring your own_ — none included |

## Project Structure

```text
ProjectName.slnx
Directory.Build.props           # Centralised build settings
Directory.Packages.props        # Central NuGet version management
global.json                     # SDK version pin
.template.config/
  template.json                 # dotnet new template metadata
src/
  AppHost/                      # .NET Aspire orchestration host
  Domain/                       # Domain entities, interfaces, value objects
  UI/                           # Blazor Server UI with Auth0
tests/
  Architecture.Tests/           # NetArchTest layer-dependency enforcement
  Integration.Tests/            # Aspire.Hosting.Testing integration tests
  Unit.Tests/                   # xUnit v3 + NSubstitute + FluentAssertions
  Component.Tests/              # BUnit Blazor component tests
  E2E.Tests/                    # Playwright end-to-end tests
docs/
README.md
LICENSE.txt
```

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download) (10.0.300 or later)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) — required by .NET Aspire for container resources
- An [Auth0](https://auth0.com/) account (free tier is sufficient)

### 1 — Create a project from the template

```bash
dotnet new aspire-blazor -n MyApp
cd MyApp
```

### 2 — Configure Auth0

Copy your Auth0 application credentials into user secrets (never commit these):

```bash
dotnet user-secrets set "Auth0:Domain" "your-tenant.auth0.com" --project src/UI
dotnet user-secrets set "Auth0:ClientId" "YOUR_CLIENT_ID" --project src/UI
dotnet user-secrets set "Auth0:ClientSecret" "YOUR_CLIENT_SECRET" --project src/UI
```

See [docs/AUTH0_SETUP.md](docs/AUTH0_SETUP.md) for full Auth0 application configuration steps.

### 3 — Restore and build

```bash
dotnet restore
dotnet build
```

### 4 — Run the application

```bash
cd src/AppHost
dotnet run
```

The .NET Aspire dashboard URL is printed to the console. Open it to inspect services, traces, and logs.

### 5 — Run all tests

```bash
dotnet test
```

## Testing

ProjectName ships with five test project types:

| Project | Purpose |
|---|---|
| `Architecture.Tests` | Enforces layer boundaries with NetArchTest.Rules |
| `Integration.Tests` | Verifies service wiring via Aspire.Hosting.Testing |
| `Unit.Tests` | Domain logic with xUnit v3, NSubstitute, FluentAssertions |
| `Component.Tests` | Blazor component rendering with BUnit |
| `E2E.Tests` | Full browser flows with Playwright |

Run a specific project:

```bash
dotnet test tests/Unit.Tests
```

## Documentation

- [CONTRIBUTING.md](docs/CONTRIBUTING.md) — Contribution guidelines and project setup
- [SECURITY.md](docs/SECURITY.md) — Vulnerability reporting and security practices
- [CODE_OF_CONDUCT.md](docs/CODE_OF_CONDUCT.md) — Community standards
- [REFERENCES.md](docs/REFERENCES.md) — Technology references and links

## License

Licensed under the MIT License. See [LICENSE](LICENSE.txt) for details.

---

**Template:** `aspire-blazor` | **.NET 10** | **Maintained by:** your-github-username
