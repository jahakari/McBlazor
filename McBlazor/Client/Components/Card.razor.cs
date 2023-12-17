using McBlazor.Client.Utility;
using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

public partial class Card : ComponentBase
{
    [Parameter]
    public RenderFragment? CardHeader { get; set; }

    [Parameter, EditorRequired]
    public RenderFragment CardBody { get; set; } = null!;

    [Parameter]
    public RenderFragment? CardFooter { get; set; }

    [Parameter]
    public BootstrapTheme Theme { get; set; } = BootstrapTheme.Primary;
}
