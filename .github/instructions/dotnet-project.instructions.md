---
applyTo: "**"
---

# .NET Project Instructions

## Technology Stack (Required)

### Framework and Language Versions

- **.NET Version:** `10.0` (latest stable)
- **Minimum SDK:** `.NET 10 SDK`
- **Runtime:** `.NET 10 Runtime` (latest stable patch version)
- All projects must target .NET 10 via `<TargetFramework>net10.0</TargetFramework>` in Directory.Build.props
- **C# Language Version:** `14.0` (latest stable)
  - Leverage latest language features when appropriate
  - Configure via `<LangVersion>14.0</LangVersion>` in the Directory.Build.props
  - All public API and class members require XML doc comments (`/// <summary>`).

---

## Style

- **Use .editorconfig:** `true`
- **Use Bootstrap:** `true`

## Testing

- Use xUnit.v3 with FluentAssertions and NSubstitute where appropriate and interfaces exist.
- Every test method must have `// Arrange`, `// Act`, `// Assert` comment markers.

## Security

- Always flag any place where user input is used without validation or sanitization.

## Response Style

- Lead each code response with a one-sentence decision rationale.
- If there is a simpler alternative approach, mention it after the primary answer.

## Guardrails

Copilot must NOT do any of the following without explicit developer confirmation:

- **No new NuGet packages** — if a task requires a new dependency, say: "This would require adding `PackageName`. Should I proceed?" and stop.
- **No secrets in code** — never hardcode connection strings, API keys, or passwords. Use `IConfiguration` or environment variables.
- **No empty catch blocks** — `catch (Exception e) {}` is never acceptable. At minimum, log and re-throw.
- **No `Thread.Sleep` in production code** — flag as a concern if encountered.
- **No schema migrations** — database changes are a human responsibility.

## Verification Checklist

Before presenting any generated code, Copilot should confirm:

- [ ] No obvious syntax errors
- [ ] Style guide followed
- [ ] No guardrails violated
- [ ] At least one test covers the change
- [ ] All tests must pass before code is presented
