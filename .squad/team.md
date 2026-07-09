# Squad Team

> ProjectTemplate

## Coordinator

| Name | Role | Notes |
|------|------|-------|
| Squad | Coordinator | Routes work, enforces handoffs and reviewer gates. |

## Members

| Name | Role | Charter | Status |
|------|------|---------|--------|
| Mal | Lead / Architect | .squad/agents/mal/charter.md | 🏗️ Active |
| Zoe | Backend Dev | .squad/agents/zoe/charter.md | 🔧 Active |
| Kaylee | Frontend Dev | .squad/agents/kaylee/charter.md | ⚛️ Active |
| Wash | DevOps / Infra | .squad/agents/wash/charter.md | ⚙️ Active |
| Jayne | Tester / QA | .squad/agents/jayne/charter.md | 🧪 Active |
| Scribe | Session Logger | .squad/agents/scribe/charter.md | 📋 Always-on |
| Ralph | Work Monitor | .squad/agents/ralph/charter.md | 🔄 Always-on |
| Rai | RAI Reviewer | .squad/agents/Rai/charter.md | 🛡️ Always-on |
| Fact Checker | Verifier | .squad/agents/fact-checker/charter.md | 🔍 Always-on |


## Coding Agent

<!-- copilot-auto-assign: false -->

| Name | Role | Charter | Status |
|------|------|---------|--------|
| @copilot | Coding Agent | — | 🤖 Coding Agent |

### Capabilities

**🟢 Good fit — auto-route when enabled:**
- Bug fixes with clear reproduction steps
- Test coverage (adding missing tests, fixing flaky tests)
- Lint/format fixes and code style cleanup
- Dependency updates and version bumps
- Small isolated features with clear specs
- Boilerplate/scaffolding generation
- Documentation fixes and README updates

**🟡 Needs review — route to @copilot but flag for squad member PR review:**
- Medium features with clear specs and acceptance criteria
- Refactoring with existing test coverage
- API endpoint additions following established patterns
- Migration scripts with well-defined schemas

**🔴 Not suitable — route to squad member instead:**
- Architecture decisions and system design
- Multi-system integration requiring coordination
- Ambiguous requirements needing clarification
- Security-critical changes (auth, encryption, access control)
- Performance-critical paths requiring benchmarking
- Changes requiring cross-team discussion

## Project Context

- **Project:** ProjectTemplate
- **Stack:** C# .NET — Aspire AppHost, Domain library, Blazor Server UI
- **Structure:** `src/` (AppHost, Domain, Blazor) · `tests/` (Architecture, Integration, Unit, BUnit, E2E)
- **Universe:** Firefly
- **Created:** 2026-07-09
- **Requested by:** mpaulosky
