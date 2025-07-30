# Git Convention

## Branch

**Format:**
`<domain>/<type>/<id>-<short-description>`

**Guideline:**

- **domain**: Your name or team/module. _E.g._: `phongnl`, `user`, `api`, `frontend`
- **type**: What kind of work? Use: `feature`, `bugfix`, `hotfix`, `refactor`, `chore`, `test`, `docs`, `release`, etc.
- **id**: Issue/task number or increment for tracking. _E.g._: `01`, `JIRA-123`
- **short-description**: Brief, lowercase, dash-separated summary. _E.g._: `login`, `can-not-login`, `update-readme`

---

### Examples
```git
phongnl/docs/05-update-api-docs
phongnl/feature/01-login
phongnl/bug/23-fix-signup-error
phongnl/test/03-add-auth-tests
phongnl/refactor/77-optimize-query
phongnl/chore/12-update-deps
```

---

### Tips

- **Keep it short and clear**.
- Use only lowercase and dashes for descriptions.
- Use consistent `domain` (your user or team/module).
- If using task tracker (JIRA, Redmine, ...), use ticket id for `id`.

---

## [Commit Message](https://www.conventionalcommits.org/en/v1.0.0/)

**Format:**

```git
<type>[optional scope]: <short description>

[optional body]

[optional footer]
```

Rules:
- type: Required. Describes the kind of change (feat, fix, docs, style, refactor, chore, etc.).
- scope: Optional. What part of the codebase? (e.g. api, auth)
- description: Required. Short, clear, in imperative mood ("add", "fix", not "added", "fixed").
- body & footer: Optional. More context or extra info (e.g. breaking changes, refs).

---

### Main Types (and Extended Types for Big Projects)

| Type     | Description                            | Example                                |
|----------|----------------------------------------|----------------------------------------|
| feat     | New feature                            | `feat: add email signup`               |
| fix      | Bug fix                                | `fix(api): handle null token`          |
| docs     | Documentation only                     | `docs: update API docs`                |
| style    | Code style, formatting, no code change | `style(ui): reformat button styles`    |
| refactor | Refactor code, no feature/bug change   | `refactor(auth): simplify login logic` |
| test     | Adding/updating tests                  | `test(api): add user auth tests`       |
| chore    | Maintenance, build, deps, configs      | `chore: update dependencies`           |
| perf     | Performance improvement                | `perf(api): cache user results`        |
| build    | Changes to build system, tools         | `build: update webpack config`         |
| ci       | CI/CD changes                          | `ci: add GitHub Actions badge`         |
| revert   | Revert previous commit(s)              | `revert: undo add email signup`        |
| deps     | Update dependencies                    | `deps: bump express to v5`             |

*Use scope in parentheses for clarity if needed (e.g. `feat(api): ...`).*

---

### Breaking Change

- Add **!** after type (and scope): `feat!: change userId to uuid` or `feat(api)!: send an email to the customer when a product is shipped`

- Or use a **BREAKING CHANGE:** footer:

```git
fix(auth): update password encryption

BREAKING CHANGE: Passwords from previous versions are invalid.
```

---

## Tag Release

### Internal

**Format:**  `v<version>-<type>.<number>`

**Rules:**
- `<version>`: Main internal build version (e.g., `100`)
- `<type>`: Tag type — use one of:
    - `test` (for internal testing builds)
    - `stag` (for staging environment)
    - `rc` (for release candidate)
- `<number>`: Incremental number (starting from 1) for each type

**Examples:**
- `v100-test.1`   (First internal test build)
- `v100-stag.2`   (Second staging build)
- `v100-rc.1`     (First release candidate build)


---
### Production

**Format:** `v<YY.MM.SPRINT>`

**Rules:**
- `YY`: Last two digits of the year (e.g., `25` for 2025)
- `MM`: Month in two digits (e.g., `07` for July)
- `SPRINT`: Sprint number in the month (`01`, `02`, ...)

**Examples:**
- `v25.07.01` (Build of sprint 01, July 2025)
- `v25.07.02` (Build of sprint 02, July 2025)


---
### Production Backup

**Format:** `v<YY.MM.SPRINT>-<YYMMDD##>`

**Rules:**
- `YY`: Last two digits of the year (e.g., `25` for 2025)
- `MM`: Month in two digits (e.g., `07` for July)
- `SPRINT`: Sprint number in the month (`01`, `02`, ...)
- `YYMMDD`: Date of the build (e.g., `250730` for July 30, 2025)
- `##`: Build sequence number for that day (e.g., `01` for the first build of the day)

**Examples:**
- `v25.07.01-25073001` (First build of sprint 01, July 30, 2025)
- `v25.07.02-25073001` (First build of sprint 02, July 30, 2025)


---

**Notes:**
- Use Internal tags for all non-production releases (test, staging, pre-release).
- Use Production tags only for official releases deployed to external/production environments.
- Do not include personal or branch information in tags.
- Consistently follow these formats for clarity and tracking.**

## Merge Request

## Review Checklist
