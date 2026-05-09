# Delphinus

![NuGet](https://img.shields.io/nuget/v/Delphinus)
![NuGet Downloads](https://img.shields.io/nuget/dt/Delphinus)
![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)
[![CI](https://github.com/marcelo-mattos/delphinus/actions/workflows/ci.yml/badge.svg)](https://github.com/marcelo-mattos/delphinus/actions/workflows/ci.yml)

**A focused .NET foundation library for predictable builders, helpers, binders, extensions, and reusable application components.**

Delphinus is designed for developers who want small, composable APIs that remove repetitive infrastructure code without hiding important behavior.

The first release is intentionally focused: **Delphinus 1.0.0 introduces a fluent SQL `WHERE` clause builder** for applications that need dynamic filtering while keeping SQL explicit and under developer control.

---

## Why Delphinus?

Delphinus exists to provide reusable building blocks that are:

- explicit and predictable
- easy to compose in application code
- lightweight enough for shared library usage
- compatible across long-lived .NET applications
- focused on reducing boilerplate without introducing hidden runtime behavior

The project favors small, stable APIs over broad abstractions.

---

## What Delphinus Is Not

Delphinus is not:

- an ORM
- a LINQ provider
- a SQL parser
- a SQL validator
- a database driver
- an automatic query generator
- an entity tracking or state management framework

The SQL fragments you pass to Delphinus remain yours. Keep external input in parameters, not in interpolated SQL strings.

---

## Supported Frameworks

- .NET Core 3.1
- .NET 6
- .NET 8
- .NET 10

---

## Key Features in 1.0.0

- `Delphinus.Builders.Query.Filters.WhereBuilder`
- Fluent SQL `WHERE` clause composition
- `Where`, `And`, `Or`, `AndNot`, and `OrNot` operators
- Conditional filter composition through `AndIf`, `OrIf`, `AndNotIf`, and `OrNotIf`
- Single-predicate and multi-predicate conditional overloads
- Action-based grouped expressions with `AndGroup`, `OrGroup`, `AndNotGroup`, and `OrNotGroup`
- Direct grouped expression helpers with `AndOrGroup` and `OrAndGroup`
- Conditional grouped variants for dynamic query scenarios
- Deterministic output: empty input returns an empty string, populated builders return a `WHERE`-prefixed clause
- `Create` and `Clear` APIs for controlled builder lifecycle and reuse
- XML documentation generation for package consumers
- Multi-targeted package support for legacy and modern .NET runtimes

---

## What's New in Delphinus 1.0.0

Delphinus 1.0.0 establishes the foundation of the library with the query-filter builder namespace.

This release delivers:

- a compact `WhereBuilder` API for dynamic SQL filter composition
- deterministic clause generation for empty and populated builders
- logical grouping for nested `AND` / `OR` scenarios
- conditional composition for optional filters
- broad framework support across `netcoreapp3.1`, `net6.0`, `net8.0`, and `net10.0`
- CI coverage across supported target frameworks
- package metadata, symbols, Source Link, XML documentation, license, and readme packaging

---

## Installation

```bash
dotnet add package Delphinus
```

---

## Basic Usage

```csharp
using Delphinus.Builders.Query.Filters;

var where = WhereBuilder
    .Create()
    .Where("customer_id = @customerId")
    .And("status = @status")
    .Build();

// WHERE customer_id = @customerId AND status = @status
```

`WhereBuilder` only builds the `WHERE` clause text. It does not execute SQL or bind parameter values.

---

## Conditional Filters

```csharp
using Delphinus.Builders.Query.Filters;

var includeInactive = false;
var hasMinimumTotal = true;

var where = WhereBuilder
    .Create()
    .Where("tenant_id = @tenantId")
    .AndIf(includeInactive, "is_active = 0")
    .AndIf(hasMinimumTotal, "total >= @minimumTotal")
    .Build();

// WHERE tenant_id = @tenantId AND total >= @minimumTotal
```

Conditional overloads are useful when an API request, UI filter, or optional command argument should add a clause only when it is present.

---

## Grouped Filters

```csharp
using Delphinus.Builders.Query.Filters;

var where = WhereBuilder
    .Create()
    .Where("tenant_id = @tenantId")
    .AndGroup(group => group
        .Where("created_at >= @startDate")
        .And("created_at < @endDate"))
    .OrGroup(group => group
        .Where("customer_name LIKE @search")
        .Or("customer_email LIKE @search"))
    .Build();

// WHERE tenant_id = @tenantId
// AND (created_at >= @startDate AND created_at < @endDate)
// OR (customer_name LIKE @search OR customer_email LIKE @search)
```

Action-based groups let you keep nested filter logic readable while preserving explicit SQL conditions.

---

## Direct Group Helpers

```csharp
using Delphinus.Builders.Query.Filters;

var where = WhereBuilder
    .Create()
    .Where("tenant_id = @tenantId")
    .AndOrGroup(
        "status = @open",
        "status = @pending")
    .OrAndGroup(
        "requires_review = 1",
        "assigned_to = @userId")
    .Build();

// WHERE tenant_id = @tenantId
// AND (status = @open OR status = @pending)
// OR (requires_review = 1 AND assigned_to = @userId)
```

Use direct group helpers when you already have complete SQL condition strings and only need Delphinus to compose the logical group.

---

## Empty Builder Behavior

```csharp
using Delphinus.Builders.Query.Filters;

var where = WhereBuilder
    .Create()
    .Build();

// string.Empty
```

This behavior makes it safe to append the result to a larger SQL command only when filters are present.

---

## Design Notes

`WhereBuilder` is intentionally small.

It:

- composes SQL condition fragments
- trims empty or whitespace-only conditions
- applies logical operators consistently
- prefixes populated output with `WHERE`
- leaves parameter binding and SQL execution to your data-access layer

It does not:

- sanitize raw user input
- validate SQL grammar
- infer table or column names
- create database parameters
- execute database commands

---

## Quality

The v1.0.0 filter-builder surface is covered by focused unit tests across all supported target frameworks.

Current local coverage snapshot for `WhereBuilder`:

| Metric | Result |
| --- | ---: |
| Line coverage | 100% |
| Branch coverage | 100% |
| Covered lines | 193 / 193 |
| Covered branches | 72 / 72 |

The GitHub Actions workflow builds the solution, runs unit tests for `netcoreapp3.1`, `net6.0`, `net8.0`, and `net10.0`, collects coverage, and validates package creation.

---

## Roadmap

See [ROADMAP.md](ROADMAP.md) for the planned evolution of Delphinus.

The project will continue to grow deliberately around reusable builders, binders, helpers, and extension APIs while preserving explicit behavior and a compact public surface.

---

## Supporting Delphinus

Delphinus is an open-source project built and maintained with care, transparency, and a long-term vision.

If Delphinus helps you build clearer and more maintainable .NET applications, consider supporting the project through GitHub Sponsors:

https://github.com/sponsors/marcelo-mattos

Every contribution, whether financial, technical, or through feedback, is deeply appreciated.

---

## License

This project is licensed under the Apache License 2.0.
See the LICENSE and NOTICE files for details.

---

## Author

**Marcelo Matos dos Santos**<br>
Software Engineer - Open Source Maintainer.<br>
Engineering clarity. Delivering transformation.
