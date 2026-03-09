using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Avalonia.Adapters;

public static class AvaloniaUiKitAdapter
{
    public static UiAdapterPayload AdaptShellChrome(ShellChrome chrome)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "shell",
            ["classes"] = $"Shell{chrome.Tone} {(chrome.Compact ? "ShellCompact" : "ShellExpanded")}"
        };

        return new UiAdapterPayload("ShellRoot", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptBanner(Banner banner)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "banner",
            ["classes"] = $"Banner{banner.Tone}{(banner.Pinned ? " BannerPinned" : string.Empty)}"
        };

        return UiAdapterPayload.Banner(banner.Tone.ToString().ToLowerInvariant(), banner.Headline, attrs);
    }

    public static UiAdapterPayload AdaptStaleStateBadge(StaleStateBadge badge)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "stale-badge",
            ["classes"] = $"StaleBadge{badge.State}",
            ["state-detail"] = badge.Detail ?? string.Empty
        };

        return new UiAdapterPayload("StaleBadge", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptApprovalChip(ApprovalChip chip)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "approval-chip",
            ["classes"] = $"ApprovalChip{(chip.IsApproved ? "Approved" : "Pending")}",
            ["text"] = chip.Label
        };

        if (!string.IsNullOrWhiteSpace(chip.Approver))
        {
            attrs["approver"] = chip.Approver;
        }

        return new UiAdapterPayload("ApprovalChip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptOfflineBanner(OfflineBanner banner)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "offline-banner",
            ["classes"] = $"OfflineBanner{(banner.IsOffline ? "Offline" : "Online")}",
            ["service"] = banner.Service
        };

        return new UiAdapterPayload("OfflineBanner", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptAccessibilityState(AccessibilityState state)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "a11y",
            ["is-busy"] = state.Busy.ToString().ToLowerInvariant(),
            ["is-disabled"] = state.Disabled.ToString().ToLowerInvariant(),
            ["live"] = state.LiveRegion
        };

        if (!string.IsNullOrWhiteSpace(state.Label))
        {
            attrs["label"] = state.Label;
        }

        if (!string.IsNullOrWhiteSpace(state.DescribedBy))
        {
            attrs["described-by"] = state.DescribedBy;
        }

        return new UiAdapterPayload("AccessibilityState", new ReadOnlyDictionary<string, string>(attrs));
    }
}
