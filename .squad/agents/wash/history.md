# Wash — History

## 2026-07-09 — Hired

Joined the ProjectTemplate crew as DevOps / Infra.

**Project:** ProjectTemplate — C# .NET template with Aspire AppHost, Domain library, and Blazor Server UI. Tests live in `tests/` (Architecture, Integration, Unit, BUnit, E2E). Source in `src/` (AppHost, Domain, Blazor).

**Requested by:** mpaulosky

## 2026-07-17 — Checked CI for Tailwind/Node dependency, no existing dotnet workflow to extend

Kaylee added a Tailwind CSS v4 npm build step wired into `UI.csproj` via an MSBuild target that runs `npm ci`/`npm run build` before build. Task was to ensure CI has Node.js on PATH before any `dotnet build`/`test` step touching `UI.csproj`.

Checked `.github/workflows/` — only squad-management automation exists (`squad-heartbeat.yml`, `squad-issue-assign.yml`, `squad-triage.yml`, `sync-squad-labels.yml`). None run `dotnet build`/`test`/`publish`, so there's nothing to add a `setup-node` step to. Did not invent a new CI pipeline — that's a bigger call than this task scope. Logged a decision asking mpaulosky whether to add a net-new dotnet CI workflow.

Also confirmed `.gitignore` already has `node_modules/` — no change needed.
