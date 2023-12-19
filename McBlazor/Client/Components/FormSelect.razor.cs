using McBlazor.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

/// <summary>
/// Renders an Html &lt;select&gt; control.
/// </summary>
/// <typeparam name="T">The type of data bound to this component.</typeparam>
public partial class FormSelect<T> : FormEditorBase<T>
{
    /// <summary>
    /// Options to render in the select list.
    /// </summary>
    [Parameter, EditorRequired]
    public IEnumerable<SelectItem<T>> Items { get; set; } = null!;
}
