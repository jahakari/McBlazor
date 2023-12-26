namespace BlazorDemo.Client.Utility;

public class BootstrapTheme
{
    private readonly string theme;

    private BootstrapTheme(string theme) => this.theme = theme;

    private string? textClass;
    public string TextClass => textClass ??= $"text-{theme}";

    private string? backgroundClass;
    public string BackgroundClass => backgroundClass ??= $"bg-{theme}";

    private string? buttonClass;
    public string ButtonClass => buttonClass ??= $"btn-{theme}";

    private string? borderClass;
    public string BorderClass => borderClass ??= $"border-{theme}";

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
