# Squad Decisions

## Active Decisions

### 2026-07-09: Use ProjectName token in all template docs

**By:** Mal (via mpaulosky request)
**Date:** 2026-07-09
**What:** README.md and all docs/ files use `ProjectName` as the dotnet new substitution token so they are automatically personalised when the template is instantiated.
**Why:** Ensures every generated project has correct project-specific documentation from day one without manual find-and-replace.

### 2026-07-16T13:03:44-0700: Keep xUnit on xunit.v3.mtp-v2 across all test projects

**By:** mpaulosky (via Copilot)
**Date:** 2026-07-16
**What:** Do not downgrade xUnit. Use `xunit.v3.mtp-v2` for all test projects and align the repository test stack around the xUnit v3 MTP path.
**Why:** Preserve the intended xUnit v3 test stack across the solution while keeping restore, build, and `dotnet test` green.

### 2026-07-17T22:35:00-0700: Replaced Bootstrap-convention CSS with Tailwind CSS v4

**By:** Kaylee (Frontend Dev)
**Date:** 2026-07-17
**What:** Replaced the hand-rolled Bootstrap-style CSS in `src/UI/wwwroot/css/app.css` with Tailwind CSS v4 (CSS-first config, no `tailwind.config.js`, no PostCSS). Added `src/UI/package.json` and `src/UI/Styles/app.tailwind.css` (with a custom `primary` color scale in `@theme` to back `FooterComponent.razor`'s existing `bg-primary-*`/`text-primary-*`/`border-primary-*` classes). Wired `TailwindNpmInstall`/`TailwindBuild` MSBuild targets into `src/UI/UI.csproj` (mirroring the existing `GetGitBuildInfo` target pattern), both skipped on `DesignTimeBuild`, so `dotnet build` regenerates the compiled CSS automatically — no manual npm step required. Preserved Blazor's framework-required CSS hooks (`#blazor-error-ui`, `.dismiss`, `.valid.modified`, `.invalid`, `.validation-message`) as plain CSS. Dropped purely decorative rules (`.btn-primary`, global `a`/`.btn-link` color, font-family reset) and applied an equivalent Tailwind utility class (`text-primary-700 hover:underline`) directly to the one link that relied on the removed global color rule. Updated `.github/instructions/dotnet-project.instructions.md` (`Use Bootstrap: true` → `Use Tailwind CSS: true`) and `.gitignore` (ignore generated `src/UI/wwwroot/css/app.css`). Verified locally: `npm install && npm run build` compiles cleanly, and `dotnet build src/UI/UI.csproj` regenerates the CSS via the MSBuild targets before compilation.
**Why:** No actual Bootstrap package was ever installed — `app.css` just used Bootstrap-named classes with hand-written rules mimicking it. Tailwind v4 gives utility-first styling with zero JS config file and native content scanning, matching what `FooterComponent.razor` was already written to expect.
**Note:** CI wiring is out of scope for this change — see Wash's decision below for the open question on whether a net-new dotnet CI workflow should be added.
**Files touched:** `src/UI/package.json` (new), `src/UI/Styles/app.tailwind.css` (new), `src/UI/UI.csproj`, `src/UI/Components/Layout/MainLayout.razor`, `.gitignore`, `.github/instructions/dotnet-project.instructions.md`, `.squad/skills/add-tailwind-css-to-blazor/SKILL.md` (new).

### 2026-07-17T22:21:31Z: No CI changes made for Tailwind/Node dependency

**By:** Wash (DevOps/Infra)
**Date:** 2026-07-17
**What:** Investigated `.github/workflows/` to add Node.js setup ahead of any `dotnet build`/`test`/`publish` step affected by Kaylee's new Tailwind CSS v4 MSBuild target in `src/UI/UI.csproj`. Found no existing dotnet build/test/CI workflow — only squad-management automation exists: `squad-heartbeat.yml`, `squad-issue-assign.yml`, `squad-triage.yml`, `sync-squad-labels.yml`. None of these run `dotnet build`, `dotnet test`, or `dotnet publish`. `.gitignore` already ignores `node_modules/` (root-level entry) — no change needed there.
**Why:** Per task scope, adding a brand-new dotnet CI workflow from scratch is a bigger decision than this task and wasn't requested — only extending an existing one was in scope. No action taken to avoid inventing a pipeline the team hasn't asked for.
**Needs decision from mpaulosky:** Should we add a net-new GitHub Actions workflow that runs `dotnet build`/`dotnet test` (and would therefore need an `actions/setup-node@v4` step, Node 20.x, before touching `src/UI/UI.csproj` transitively via Integration.Tests/E2E.Tests)? If yes, Wash can build it — including npm caching via `cache: 'npm'` + `cache-dependency-path: src/UI/package-lock.json` now that Kaylee's `package-lock.json` exists.
**Files touched:** None (investigation only).

### 2026-07-17: Relocate Tailwind CSS skill to personal path

**By:** Squad (Coordinator), per mpaulosky's explicit choice
**Date:** 2026-07-17
**What:** The `add-tailwind-css-to-blazor` skill (originally authored by Kaylee at `.squad/skills/add-tailwind-css-to-blazor/SKILL.md`, then verified accurate by Fact Checker) was moved — not copied — to `~/.copilot/skills/add-tailwind-css-to-blazor/SKILL.md`. It no longer lives in this repo.
**Why:** mpaulosky wants this skill reusable across all their projects, not just ones scaffolded from this template. Personal-path skills (`~/.copilot/skills/`) are injected as ambient context by Copilot CLI for every session regardless of repo, but are explicitly NOT scanned by Squad's project skill-aware routing (see squad.agent.md's "Personal paths not scanned" note). Consequence: this squad will no longer auto-surface this skill via its `.squad/skills/` precedence check — if a future ProjectTemplate contributor needs it, it will need to be re-added to `.github/skills/` or `.squad/skills/` explicitly.

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
