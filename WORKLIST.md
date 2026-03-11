# Worklist

- [done] Bootstrap repo structure and package boundaries
- [done] Seed token canon, theme compilation, and preview/gallery ownership
- [done] Establish full `U0-U9` milestone coverage truth with explicit status, completion percent, and ETA in `.codex-design/repo/UI_KIT_MILESTONE_COVERAGE.yaml`.

## Queue Slice: B1 package-only shared boundary (tokens + shell chrome + accessibility)

- [ ] Migrate shared token references used by presentation/play into `TokenCanon` additions and document token keys in `README.md`.
- [ ] Expand shell chrome primitives/adapters for package-only consumption (no app-specific service/domain assumptions).
- [ ] Finalize accessibility primitive payloads for shared busy/live/disabled/status semantics in both Blazor and Avalonia adapters.
- [ ] Add/extend contract-style tests proving shell chrome and accessibility adapter outputs are deterministic and UI-kit only.
- [ ] Publish package-consumption checklist for presentation/play confirming no source-copy UI primitives remain for this slice.

### Runnable backlog append: package-only consumption closure

- [ ] `ui-kit`: Expand `README.md` with a "B1 token + shell chrome + accessibility contract" section that lists canonical token keys and adapter payload guarantees.
- [ ] `ui-kit`: Add a test in `tests/Chummer.Ui.Kit.Tests/Program.cs` that asserts `TokenCanon.CreateDefault()` contains the shell + accessibility token keys used by adapters.
- [ ] `presentation`: Replace any local/source-copied shell chrome or accessibility classes with `Chummer.Ui.Kit` package usage.
- [ ] `play`: Replace any local/source-copied shell chrome or accessibility classes with `Chummer.Ui.Kit` package usage.
- [ ] `presentation` + `play`: Add boundary checks (`rg`/CI guard) that fail when repo-local copies of B1 primitives are reintroduced.
- [ ] `presentation` + `play`: Capture package adoption evidence (commit + path list) and link it back to this repo queue slice for closure.

## Milestone modeling follow-through (from coverage file)

- [ ] U4 dense-data controls: publish runnable extraction backlog and acceptance criteria.
- [ ] U5 Chummer-specific patterns: publish runnable migration backlog for state badges/explain chips/artifact patterns.
- [ ] U7 visual regression/catalog: publish queue items for catalog surface + regression harness.
- [ ] U8 release discipline: publish queue items for package release gates and verification checklist.
