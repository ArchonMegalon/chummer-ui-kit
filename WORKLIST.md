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

## Queue Slice: U4/U5 centralization (dense data + state badges + explain chips + Chummer patterns)

Milestone mapping:
- [ ] `U4 Dense-data controls` -> package-owned dense row and table primitives with deterministic adapter payloads.
- [ ] `U5 Chummer-specific patterns` -> package-owned explain chips, stale/approval state badges, and reusable Chummer cards.

Runnable backlog:
- [ ] `ui-kit`: Add dense-data primitives in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` for sortable headers, dense-row metadata, row-state emphasis, and explain-affinity hints without domain DTO fields.
- [ ] `ui-kit`: Implement Blazor/Avalonia adapter methods for each dense-data primitive with stable payload keys and role/class mappings.
- [ ] `ui-kit`: Add explicit `ExplainChip`, `SpiderStatusCard`, and `ArtifactStatusCard` primitives in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` with UI-only inputs.
- [ ] `ui-kit`: Extend Blazor/Avalonia adapters with payload builders for explain chip and card patterns; include accessibility attributes where relevant.
- [ ] `ui-kit`: Register `dense_data`, `explain_patterns`, and `chummer_cards` preview entries in `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs`.
- [ ] `ui-kit`: Add deterministic contract tests in `tests/Chummer.Ui.Kit.Tests/Program.cs` covering all new dense-data and pattern payloads.
- [ ] `presentation`: Replace local dense table state badges/chips/cards with `Chummer.Ui.Kit` package primitives.
- [ ] `play`: Replace local dense table state badges/chips/cards with `Chummer.Ui.Kit` package primitives.
- [ ] `presentation` + `play`: Add guard checks that fail CI if local/source-copied dense-data or explain/state pattern components reappear.
- [ ] `presentation` + `play`: Record adoption evidence (paths + commits) and attach it to this queue slice to close auditor finding `487871/487874`.

Acceptance criteria:
- [ ] No domain DTOs, provider SDKs, HTTP clients, or external-tool business logic are introduced.
- [ ] New primitives are package-only, adapter-only, deterministic, and reusable across presentation and play.
- [ ] Preview manifest and tests provide closure evidence for U4/U5 centralization work.

## Milestone modeling follow-through (from coverage file)

- [ ] U4 dense-data controls: publish runnable extraction backlog and acceptance criteria.
- [ ] U5 Chummer-specific patterns: publish runnable migration backlog for state badges/explain chips/artifact patterns.
- [ ] U7 visual regression/catalog: publish queue items for catalog surface + regression harness.
- [ ] U8 release discipline: publish queue items for package release gates and verification checklist.
