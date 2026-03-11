# Worklist

- [done] Bootstrap repo structure and package boundaries
- [done] Seed token canon, theme compilation, and preview/gallery ownership

## Queue Slice: B1 package-only shared boundary (tokens + shell chrome + accessibility)

- [ ] Migrate shared token references used by presentation/play into `TokenCanon` additions and document token keys in `README.md`.
- [ ] Expand shell chrome primitives/adapters for package-only consumption (no app-specific service/domain assumptions).
- [ ] Finalize accessibility primitive payloads for shared busy/live/disabled/status semantics in both Blazor and Avalonia adapters.
- [ ] Add/extend contract-style tests proving shell chrome and accessibility adapter outputs are deterministic and UI-kit only.
- [ ] Publish package-consumption checklist for presentation/play confirming no source-copy UI primitives remain for this slice.
