using Chummer.Ui.Kit.Preview;
using Chummer.Ui.Kit.Theming;
using Chummer.Ui.Kit.Tokens;
using Chummer.Ui.Kit.Adapters;
using Chummer.Ui.Kit.Blazor.Adapters;
using Chummer.Ui.Kit.Avalonia.Adapters;

var checks = new Action[]
{
    DefaultCanonContainsExpectedTokens,
    CompilerProducesCssVariablesFromCanonAndOverrides,
    CompilerRejectsUnknownOverrideKeys,
    PreviewGalleryDefaultManifestStaysWithinUiKitBoundary,
    BlazorAndAvaloniaAdaptersEmitExpectedClasses,
    AdapterPayloadContainsAccessibilityAttributes
};

foreach (var check in checks)
{
    check();
    Console.WriteLine($"PASS {check.Method.Name}");
}

return 0;

static void DefaultCanonContainsExpectedTokens()
{
    var canon = TokenCanon.CreateDefault();

    ExpectEqual("#F7F3EA", canon["color.background.canvas"], "canvas color");
    ExpectEqual("1rem", canon["space.400"], "space token");
    ExpectEqual("\"IBM Plex Sans\", \"Segoe UI\", sans-serif", canon["font.family.base"], "font family");
}

static void CompilerProducesCssVariablesFromCanonAndOverrides()
{
    var canon = TokenCanon.CreateDefault();
    var definition = new ThemeDefinition(
        "desert",
        canon,
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["color.accent.primary"] = "#A85C3B",
            ["radius.md"] = "0.75rem"
        });

    var compiled = new ThemeCompiler().Compile(definition);

    ExpectEqual("desert", compiled.Name, "theme name");
    ExpectContains(compiled.CssVariables, "--color-accent-primary: #A85C3B;", "accent css variable");
    ExpectContains(compiled.CssVariables, "--radius-md: 0.75rem;", "radius css variable");
    ExpectEqual("#A85C3B", compiled.ResolvedTokens["color.accent.primary"], "resolved accent token");
}

static void CompilerRejectsUnknownOverrideKeys()
{
    var canon = TokenCanon.CreateDefault();
    var definition = new ThemeDefinition(
        "broken",
        canon,
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["api.endpoint"] = "https://example.invalid"
        });

    try
    {
        _ = new ThemeCompiler().Compile(definition);
        throw new InvalidOperationException("Expected compiler to reject unknown override.");
    }
    catch (InvalidOperationException ex) when (ex.Message.Contains("Unknown token override", StringComparison.Ordinal))
    {
    }
}

static void PreviewGalleryDefaultManifestStaysWithinUiKitBoundary()
{
    var manifest = PreviewGalleryManifest.CreateDefault();

    ExpectEqual("Chummer.Ui.Kit", manifest.Ownership.Owner, "manifest owner");
    ExpectEqual("preview/gallery", manifest.Ownership.Route, "manifest route");
    ExpectContains(manifest.Ownership.Notes, "domain DTOs or HTTP clients", "ownership boundary");
    ExpectTrue(manifest.Previews.ContainsKey("components"), "components preview registration");
    ExpectTrue(manifest.Previews.ContainsKey("shell_chrome"), "shell chrome preview registration");
    ExpectTrue(manifest.Previews.ContainsKey("banners"), "banners preview registration");
    ExpectTrue(manifest.Previews.ContainsKey("chips"), "chips preview registration");
    ExpectTrue(manifest.Previews.ContainsKey("accessibility"), "accessibility preview registration");
}

static void BlazorAndAvaloniaAdaptersEmitExpectedClasses()
{
    var chrome = new ShellChrome("Main", "Workspace", ShellChromeTone.Focused, compact: true);
    var blazorChrome = BlazorUiKitAdapter.AdaptShellChrome(chrome);
    var avaloniaChrome = AvaloniaUiKitAdapter.AdaptShellChrome(chrome);

    ExpectEqual("chummer-shell", blazorChrome.RootClass, "blazor shell root class");
    ExpectContains(blazorChrome.Attributes["class"], "chummer-shell-focused", "blazor focused tone class");
    ExpectContains(blazorChrome.Attributes["class"], "chummer-shell-compact", "blazor compact chrome class");

    ExpectEqual("ShellRoot", avaloniaChrome.RootClass, "avalonia shell root class");
    ExpectContains(avaloniaChrome.Attributes["classes"], "ShellFocused", "avalonia focus class");
    ExpectContains(avaloniaChrome.Attributes["classes"], "ShellCompact", "avalonia compact class");
}

static void AdapterPayloadContainsAccessibilityAttributes()
{
    var state = new AccessibilityState("assertive", busy: true, disabled: false, label: "Loading panel");
    var blazor = BlazorUiKitAdapter.AdaptAccessibilityState(state);
    var avalonia = AvaloniaUiKitAdapter.AdaptAccessibilityState(state);

    ExpectEqual("true", blazor.Attributes["aria-busy"], "blazor busy attribute");
    ExpectEqual("assertive", blazor.Attributes["aria-live"], "blazor live attribute");
    ExpectEqual("Loading panel", blazor.Attributes["aria-label"], "blazor label attribute");

    ExpectEqual("true", avalonia.Attributes["is-busy"], "avalonia busy attribute");
    ExpectEqual("assertive", avalonia.Attributes["live"], "avalonia live attribute");
    ExpectEqual("Loading panel", avalonia.Attributes["label"], "avalonia label attribute");
}

static void ExpectEqual(string expected, string actual, string scenario)
{
    if (!string.Equals(expected, actual, StringComparison.Ordinal))
    {
        throw new InvalidOperationException($"Expected {scenario} to be '{expected}' but was '{actual}'.");
    }
}

static void ExpectContains(string source, string fragment, string scenario)
{
    if (!source.Contains(fragment, StringComparison.Ordinal))
    {
        throw new InvalidOperationException($"Expected {scenario} to contain '{fragment}'.");
    }
}

static void ExpectTrue(bool condition, string scenario)
{
    if (!condition)
    {
        throw new InvalidOperationException($"Expected {scenario}.");
    }
}
