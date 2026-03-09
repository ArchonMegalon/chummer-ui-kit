using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Preview;

public sealed class PreviewGalleryManifest
{
    public PreviewGalleryManifest(
        PreviewGalleryOwnership ownership,
        IReadOnlyDictionary<string, string> previews)
    {
        Ownership = ownership ?? throw new ArgumentNullException(nameof(ownership));
        ArgumentNullException.ThrowIfNull(previews);

        if (previews.Count == 0)
        {
            throw new ArgumentException("At least one preview entry is required.", nameof(previews));
        }

        Previews = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>(
                previews.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal),
                StringComparer.Ordinal));
    }

    public PreviewGalleryOwnership Ownership { get; }

    public IReadOnlyDictionary<string, string> Previews { get; }

    public static PreviewGalleryManifest CreateDefault()
    {
        return new PreviewGalleryManifest(
            PreviewGalleryOwnership.CreateDefault(),
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
            ["tokens"] = "Canonical token surface and raw values.",
            ["themes"] = "Compiled theme output and CSS variable inspection.",
            ["components"] = "Component gallery owned by the UI kit package.",
            ["shell_chrome"] = "Shell chrome and state adapters for Blazor and Avalonia.",
            ["banners"] = "Banner and stale-state badge primitives with adapter mappings.",
            ["chips"] = "Approval chip and offline banner adapter payloads.",
            ["accessibility"] = "Accessibility and state primitives for UI-kit adapters."
        });
    }
}
