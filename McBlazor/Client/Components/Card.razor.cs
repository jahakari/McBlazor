using McBlazor.Client.Utility;
using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

/// <summary>
/// Renders a Bootstrap Card
/// </summary>
public partial class Card : ComponentBase
{
    /// <summary>
    /// Optional content to render in the Card Header.
    /// </summary>
    [Parameter]
    public RenderFragment? CardHeader { get; set; }

    /// <summary>
    /// Content to render in the Card Body.
    /// </summary>
    [Parameter, EditorRequired]
    public RenderFragment CardBody { get; set; } = null!;

    /// <summary>
    /// Optional content to render in the Card Footer.
    /// </summary>
    [Parameter]
    public RenderFragment? CardFooter { get; set; }

    /// <summary>
    /// The Bootstrap theme color to user for the Card border and Header background.
    /// </summary>
    [Parameter]
    public BootstrapTheme Theme { get; set; } = BootstrapTheme.Primary;
}
