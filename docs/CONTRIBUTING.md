# Contributing to Helmz.Core

## Branch Workflow

1. **Always work in a PR branch** — never commit directly to `main`.
2. Create a feature branch from `main`:
   ```bash
   git checkout main
   git pull origin main
   git checkout -b <type>/<short-description>
   ```
3. Push your branch and open a Pull Request.
4. All changes must be reviewed and merged via PR.

## Commit Convention

We use [Conventional Commits](https://www.conventionalcommits.org/).

Format:
```
<type>(<scope>): <description>

[optional body]

[optional footer(s)]
```

### Types

| Type | Description |
|------|-------------|
| `feat` | A new feature |
| `fix` | A bug fix |
| `docs` | Documentation only changes |
| `style` | Code style changes (formatting, no logic change) |
| `refactor` | Code change that neither fixes a bug nor adds a feature |
| `perf` | Performance improvement |
| `test` | Adding or updating tests |
| `build` | Changes to build system or dependencies |
| `ci` | CI/CD configuration changes |
| `chore` | Other changes that don't modify src or test files |

### Scopes

| Scope | Description |
|-------|-------------|
| `crypto` | Encryption / key exchange (X25519, AES-256-GCM) |
| `proto` | Protocol messages and serialization |
| `room` | Room management and pair codes |
| `config` | Configuration and options |

### Examples

```
feat(proto): add session status payload type
fix(crypto): handle key disposal correctly
refactor(room): extract pair code validation
test(crypto): add AES-GCM round-trip tests
```

## Code Quality

All Roslyn IDE suggestions are enforced as build errors. Run `dotnet format` before committing to auto-fix violations.

See the [parent repo's contributing guide](https://github.com/HelmzAI/Helmz/blob/main/docs/CONTRIBUTING.md#code-quality) for the full list of enforced rules.

## Merging

- **Always squash merge** PRs into `main`.
- The squash commit message must follow conventional commit format.
- **Always delete the branch** after merging.

## Summary

```
main (protected)
  └── feat/my-feature (PR branch)
        ├── feat(scope): commit 1
        ├── fix(scope): commit 2
        └── squash merge → main → delete branch
```
