# Skill: Write Tests

## Purpose

Generate xUnit.v3 unit, component, integration, and E2E tests for a .NET class or method following team conventions.

## Trigger

Use when asked to "write tests", "add unit tests", or "test this method".

## Steps

1. Identify the class and method(s) under test, and which layer it lives in (`src/Domain`, `src/UI`, `src/AppHost`, etc.).
2. Pick the matching test project based on what is being tested — do not mix scopes:
   - `tests/Unit.Tests` — isolated logic, no I/O, no Aspire host (e.g. `Domain` classes/methods).
   - `tests/Component.Tests` — a single component/service in isolation (e.g. a Blazor component or handler).
   - `tests/Integration.Tests` — behavior across boundaries, including Aspire `AppHost` distributed app tests.
   - `tests/E2E.Tests` — full end-to-end flows through the running app.
   - `tests/Architecture.Tests` — layering/dependency rules, not individual behavior.
3. Create or locate the corresponding `*Tests.cs` file in that project. Namespace must follow `ProjectName.<TestProject>` (e.g. `ProjectName.Unit.Tests`), matching the existing files in that folder.
4. For each method, write tests covering:
   - The happy path (valid input, expected output)
   - Boundary conditions (empty list, index 0, max index)
   - Error/exception cases (null input, out-of-range index)
5. Every test method must follow this structure, with all three comment markers present even if a section has no code:

   ```csharp
   [Fact]
   public void MethodName_Scenario_ExpectedBehavior()
   {
       // Arrange

       // Act

       // Assert
   }
   ```

6. Use FluentAssertions for assertions (`result.Should().Be(...)`), not the bare `Assert` class.
7. If the class under test depends on an interface, use NSubstitute (`Substitute.For<IThing>()`) to fake it; add the `NSubstitute` package reference to the test `.csproj` only if it isn't already there.

## Guardrails

- Do NOT use `Moq` or any mocking library other than `NSubstitute`.
- Do NOT use `NSubstitute` unless the class has interface dependencies to fake.
- Do NOT use `[Theory]` with inline data unless there are 3+ similar cases.
- Test method names must follow the `Method_Scenario_ExpectedBehavior` convention.
- Do NOT add a new NuGet package without calling it out and asking for confirmation first, per repo guardrails.
- All new/changed tests must pass before the code is presented.
