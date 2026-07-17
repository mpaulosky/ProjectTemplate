# Kaylee — History

## 2026-07-09 — Hired

Joined the ProjectTemplate crew as Frontend Dev.

**Project:** ProjectTemplate — C# .NET template with Aspire AppHost, Domain library, and Blazor Server UI. Tests live in `tests/` (Architecture, Integration, Unit, BUnit, E2E). Source in `src/` (AppHost, Domain, Blazor).

**Requested by:** mpaulosky

## 2026-07-17 — Replaced Bootstrap-convention CSS with Tailwind CSS v4

Added Tailwind CSS v4 to `src/UI/` (CSS-first config, no `tailwind.config.js`).
New `package.json` + `Styles/app.tailwind.css` (with a custom `primary` color
scale to back `FooterComponent.razor`'s pre-existing `bg-primary-*` classes).
Wired `TailwindNpmInstall`/`TailwindBuild` MSBuild targets into `UI.csproj`
mirroring the existing `GetGitBuildInfo` pattern, both skipped on
`DesignTimeBuild`, so `dotnet build` regenerates the compiled CSS
automatically. Preserved Blazor's framework-required CSS hooks
(`#blazor-error-ui`, form-validation classes) as plain CSS; dropped purely
decorative Bootstrap-mimicking rules and applied an equivalent Tailwind
utility class where markup relied on a removed global rule. Updated
`.github/instructions/dotnet-project.instructions.md` and `.gitignore`.
Wrote a reusable skill doc at
`.squad/skills/add-tailwind-css-to-blazor/SKILL.md`. Verified locally:
`npm install && npm run build` compiles cleanly, and `dotnet build` fires the
MSBuild targets and regenerates the CSS. Logged decision at
`.squad/decisions/inbox/kaylee-tailwind-css.md`. CI wiring left to Wash (see
his inbox decision on whether a net-new dotnet CI workflow is needed).

**Requested by:** mpaulosky (via Squad Coordinator)

📌 Team update (2026-07-17T22:51:00Z): The `add-tailwind-css-to-blazor` skill you authored was relocated out of this repo to mpaulosky's personal skills path (`~/.copilot/skills/add-tailwind-css-to-blazor/SKILL.md`), per their request to reuse it across all personal projects. It's no longer in `.squad/skills/` and won't be auto-surfaced by this squad's skill-aware routing — decided by Squad (Coordinator).

## 2026-07-17 — Split Tailwind minification by build Configuration

Follow-up to the Tailwind v4 setup above: `npm run build` no longer always
minifies. Split `src/UI/package.json`'s script into `build` (unminified,
default/Debug) and `build:release` (`--minify`, Release); `watch` unchanged.
`UI.csproj`'s `TailwindBuild` target now has two `<Exec>` elements gated on
`'$(Configuration)' == 'Release'` / `!= 'Release'`, matching the file's
existing MSBuild style. Updated the target's doc comment and the
`add-tailwind-css-to-blazor` skill doc to describe the split.
Verified directly: `npm run build` → 7796-byte readable CSS, `npm run
build:release` → 6618-byte minified CSS. `dotnet build -c Debug` and
`-c Release` both correctly invoke the matching npm script (confirmed via
build output), but the overall `dotnet build` fails on both configs due to
pre-existing, unrelated errors in `Routes.razor`/`FooterComponent.razor`
(in-progress Auth0 work already showing as uncommitted changes before this
session started) — out of scope for this task.

**Requested by:** mpaulosky (via Squad Coordinator)
