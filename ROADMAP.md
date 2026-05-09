# Delphinus Roadmap

This document outlines the planned evolution of **Delphinus**.

The roadmap reflects the project's core philosophy: **small reusable APIs, predictable behavior, and minimal hidden abstraction**.

Features are added deliberately, prioritizing clarity, long-term compatibility, testability, and practical application value.

---

## Guiding Principles

- Keep APIs explicit and easy to reason about
- Prefer small composable building blocks over broad frameworks
- Avoid hidden runtime behavior
- Preserve compatibility across supported .NET versions
- Keep dependencies intentional and lightweight
- Favor deterministic output and fail-fast validation where appropriate
- Maintain a compact and stable public API surface
- Document behavior clearly enough for package consumers to trust it

---

## v1.0 - Foundation Query Filters (Release Line)

Focus: **establish the Delphinus foundation with a predictable SQL filter builder**

### Delivered

- Initial `Delphinus` package structure and metadata
- `Delphinus.Builders.Query.Filters` namespace
- Fluent `WhereBuilder` for SQL `WHERE` clause composition
- `Where`, `And`, `Or`, `AndNot`, and `OrNot` operators
- Conditional filter composition through `*If` overloads
- Support for single `bool` predicates and `bool[]` predicate sets
- Action-based grouped expressions through `AndGroup`, `OrGroup`, `AndNotGroup`, and `OrNotGroup`
- Direct grouped expression helpers through `AndOrGroup` and `OrAndGroup`
- Conditional grouped variants for dynamic filter scenarios
- Deterministic `Build()` behavior:
  - returns `string.Empty` when no filters are present
  - returns a `WHERE`-prefixed clause when conditions exist
- `Create()` and `Clear()` APIs for controlled builder lifecycle and reuse
- XML documentation generation
- NuGet package metadata, symbols, Source Link, license, notice, icon, and readme packaging
- Multi-target support for `netcoreapp3.1`, `net6.0`, `net8.0`, and `net10.0`
- Unit test coverage for the complete v1.0 filter-builder surface
- GitHub Actions workflow for build, test, coverage collection, and package validation

### Quality Baseline

- 89 focused unit tests for `WhereBuilder`
- 100% line coverage in the current local coverage snapshot
- 100% branch coverage in the current local coverage snapshot
- CI execution across all supported target frameworks

---

## v1.1 - Query Builder Solidification (Planned)

Focus: **rounding out query composition while keeping SQL explicit**

### Planned

- Additional query-clause builders where they provide clear value without becoming a SQL generator
- More examples for optional filters, grouped filters, and application search screens
- Expanded edge-case testing for whitespace, empty groups, nested groups, and reuse flows
- Improved documentation for safe usage with parameterized SQL
- API review for naming consistency across all builder methods
- Additional XML documentation polish for package consumers
- More package validation scenarios before release

### Compatibility Goal

- Existing v1.0 `WhereBuilder` usage should continue to work unchanged.
- Any new query builder APIs should remain additive.

---

## v1.2 - Foundation Helpers and Extensions (Planned)

Focus: **expanding Delphinus into a broader foundation library without diluting the API**

### Direction

- Reusable helper APIs for common application code paths
- Extension methods that remove repetitive infrastructure code while staying explicit
- Guard and validation helpers where they improve readability and reduce duplicated checks
- Binder-oriented utilities for controlled object and value mapping scenarios
- Documentation examples that show how the pieces fit together in real services
- Continued package hygiene across supported target frameworks

---

## v2.0 - Component Maturity (Planned)

Focus: **stabilizing a broader foundation toolkit after the first API families prove useful**

### Direction

- Public API review across builders, helpers, binders, and extensions
- Stronger consistency rules for naming, null handling, and deterministic output
- Performance review for frequently used helpers
- Compatibility guidance for applications upgrading from 1.x
- More complete documentation and cookbook-style usage examples
- Release notes and migration guidance for any breaking changes, if required

---

## vNext - Operational and Ecosystem Evolution (Planned)

Focus: **maintainability, documentation, automation, and long-term project health**

### Direction

- Benchmark or micro-benchmark coverage for hot helper paths where performance matters
- Additional CI/CD quality gates when they add real signal
- Expanded examples for package consumers
- Improved contribution guidance for new API proposals
- Continued support for long-lived .NET applications where feasible
- Conservative dependency management and package-size discipline

---

## Explicitly Out of Scope

The following features are intentionally not part of the current Delphinus direction:

- ORM behavior
- LINQ query translation
- Automatic SQL generation
- Database provider abstraction
- SQL parsing or grammar validation
- Entity tracking or change detection
- Hidden query execution
- Runtime behavior that obscures what application code is doing

Delphinus will remain a **foundation library** built around explicit, composable, developer-controlled APIs.

---

## Roadmap Philosophy

Delphinus evolves conservatively.

Every new feature should:

- reduce meaningful application boilerplate
- preserve explicit behavior
- keep the public API understandable
- remain easy to test
- avoid unnecessary dependencies
- work across the supported target frameworks
- improve maintainability without introducing surprising behavior

---

## Contributions and Feedback

Community feedback is welcome and helps guide the roadmap.

Feature requests should align with the guiding principles above and should describe the repetitive application problem they are intended to solve.

---

## Author

**Marcelo Matos dos Santos**<br>
Software Engineer - Open Source Maintainer.
