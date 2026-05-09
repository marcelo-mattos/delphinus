# Contributing to Delphinus

Thank you for your interest in contributing to **Delphinus**!
We welcome contributions that help improve quality, usability, stability, extensibility, and documentation.

Delphinus is a developer support library focused on extensions, builders, binders, helpers, and reusable utilities that make software development cleaner, faster, and more consistent.

This document outlines the guidelines for contributing to this project.

---

## 🚀 How to Contribute

You can contribute in several ways:

- Reporting bugs
- Suggesting enhancements
- Improving documentation
- Submitting code changes through Pull Requests
- Proposing new extensions, builders, binders, helpers, or utility components

---

## 🐞 Reporting Bugs

When reporting a bug, please include:

- A clear and descriptive title
- Steps to reproduce the issue
- Expected behavior
- Actual behavior
- Environment details, such as OS, .NET version, runtime, framework, package version, or related tooling
- Relevant logs, stack traces, screenshots, or minimal reproducible examples, if available

---

## 💡 Suggesting Enhancements

Feature requests are welcome. Please provide:

- A clear description of the problem the feature solves
- A proposed solution or approach
- Example usage, when applicable
- Any potential impact on performance, compatibility, maintainability, or public APIs

---

## 🔧 Code Contributions

### Fork & Branch

- Fork the repository
- Create a branch from `main` or `develop`
- Use a clear and descriptive branch name

Examples:

- `feature/string-builder-extensions`
- `feature/options-binder`
- `fix/null-value-extension`
- `docs/update-readme`

### Coding Guidelines

- Follow the existing code style and project structure
- Keep methods small, readable, and easy to maintain
- Prefer explicit, clear abstractions over clever or overly complex code
- Keep cognitive complexity reasonable
- Avoid unnecessary allocations and reflection in performance-sensitive paths
- Preserve backward compatibility whenever possible
- Document public APIs with XML documentation when applicable
- Write meaningful commit messages

### Tests

- Add or update tests when applicable
- Cover normal flows, edge cases, and invalid inputs
- Ensure all tests pass before submitting a Pull Request
- Include regression tests for bug fixes whenever possible

---

## 📦 Pull Request Guidelines

Before submitting a Pull Request, please make sure that:

- The change has a clear purpose and scope
- The code builds successfully
- Existing tests continue to pass
- New or changed behavior is covered by tests when applicable
- Documentation was updated when the public API or expected usage changed
- The Pull Request description explains what changed and why

---

## 📜 License & Contributions

By submitting a contribution, you agree that:

- Your contribution will be licensed under the **Apache License 2.0**
- You grant the project a perpetual, worldwide, royalty-free license to use your contribution as part of the project
- You certify that you have the right to submit the contribution and that it does not infringe third-party rights

This project does **not** require a separate CLA (Contributor License Agreement).
The **Apache License 2.0** governs all contributions.

---

## 🤝 Code of Conduct

Please be respectful and constructive in all interactions.
Harassment, abusive language, discrimination, or unprofessional behavior will not be tolerated.

All contributors are expected to follow the project's Code of Conduct.

---

Thank you for helping improve **Delphinus**!
