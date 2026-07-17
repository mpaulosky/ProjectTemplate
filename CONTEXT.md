# ProjectTemplate

A .NET 10 solution scaffolded with Squad, an AI-team framework that manages coordination state under `.squad/` and Copilot-facing configuration under `.github/`.

## Language

**Instruction file**:
A Markdown file GitHub Copilot auto-loads into every request's context without being asked — either `.github/copilot-instructions.md` (repo-wide, no frontmatter) or `.github/instructions/*.instructions.md` (scoped via `applyTo` frontmatter glob).
_Avoid_: customization file, config file

**Coding Agent**:
The GitHub-hosted, asynchronous `@copilot` bot that picks up assigned issues, works unattended, and opens its own PR. Distinct from interactive Copilot Chat/Agent mode sessions — it reads `.github/copilot-instructions.md` as its only configuration surface (no charter file).
_Avoid_: Copilot, the agent, coding agent mode

**Squad-owned file**:
A file listed in squad-cli's `TEMPLATE_MANIFEST` with `overwriteOnUpgrade: true`. `squad upgrade` performs a raw, unconditional overwrite of these files whenever the enabling condition is met — no diff, no merge, no markers. `.github/copilot-instructions.md` is squad-owned whenever `.squad/team.md` contains the literal string `🤖 Coding Agent`.
_Avoid_: managed file, template file (ambiguous — templates/ vs. manifest-owned are different things)

**On-demand reference**:
A doc under `.squad/templates/` that Squad's coordinator reads only when a specific trigger occurs (e.g. adding `@copilot`), as opposed to the "core rules" embedded directly in `squad.agent.md` that are always in context.
_Avoid_: template (too broad — also used for scaffolding files)

## Relationships

- **Coding Agent branch convention**: `copilot/{slug}` — set by GitHub itself, not overridable via instructions. Reconciled across `squad.agent.md` and `.squad/templates/copilot-agent.md` on 2026-07-17. `.squad/templates/copilot-agent.md`'s comparison table still shows the old `squad/{issue}-{slug}` value for spawned (non-@copilot) agents only — that's correct and intentional, it's a different actor.
- **Instruction file ownership split**: `.github/copilot-instructions.md` is exclusively Squad's Coding-Agent config (squad-owned, safe to let `squad upgrade` overwrite). Project-specific coding standards live in `.github/instructions/dotnet-project.instructions.md` (`applyTo: "**"`) instead, since that path is outside `TEMPLATE_MANIFEST` and survives upgrades untouched.
