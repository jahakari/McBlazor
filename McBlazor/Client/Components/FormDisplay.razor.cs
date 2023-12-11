using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

public partial class FormDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public string Label { get; set; } = null!;

    [Parameter]
    public string? Note { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? For { get; set; }

    [Parameter]
    public bool IsRequired { get; set; }

    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;
}
