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

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
