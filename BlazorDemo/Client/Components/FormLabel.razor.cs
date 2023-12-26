using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

/// <summary>
/// This component renders a label above specified child content
/// </summary>
public partial class FormLabel : ComponentBase
{
    /// <summary>
    /// The label text.
    /// </summary>
    [Parameter, EditorRequired]
    public string Label { get; set; } = null!;

    /// <summary>
    /// Optional note text to render to the right of the label.
    /// </summary>
    [Parameter]
    public string? Note { get; set; }

    /// <summary>
    /// Optional text for the label/content container "title" attribute.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }

    /// <summary>
    /// The id of an element the label is for.
    /// </summary>
    [Parameter]
    public string? For { get; set; }

    /// <summary>
    /// When <see langword="true" />, renders a red asterisk to the right of the label.
    /// </summary>
    [Parameter]
    public bool IsRequired { get; set; }

    /// <summary>
    /// Content to render below the label.
    /// </summary>
    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;
}
