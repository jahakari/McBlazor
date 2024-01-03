namespace BlazorDemo.Client.Utility;

public class BootstrapTheme
{
    private readonly string _theme;

    private BootstrapTheme(string theme) => _theme = theme;

    private string? _textClass;
    public string TextClass => _textClass ??= $"text-{_theme}";

    private string? _backgroundClass;
    public string BackgroundClass => _backgroundClass ??= $"bg-{_theme}";

    private string? _buttonClass;
    public string ButtonClass => _buttonClass ??= $"btn-{_theme}";

    private string? _borderClass;
    public string BorderClass => _borderClass ??= $"border-{_theme}";

    public static BootstrapTheme Primary { get; } = new("primary");
    public static BootstrapTheme Secondary { get; } = new("secondary");
    public static BootstrapTheme Success { get; } = new("success");
    public static BootstrapTheme Danger { get; } = new("danger");
    public static BootstrapTheme Warning { get; } = new("warning");
    public static BootstrapTheme Info { get; } = new("info");
    public static BootstrapTheme Light { get; } = new("light");
    public static BootstrapTheme Dark { get; } = new("dark");
    public static BootstrapTheme White { get; } = new("white");
}
