using McBlazor.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

public partial class FormSelect<T> : FormEditorBase<T>
{
    [Parameter, EditorRequired]
    public IEnumerable<SelectItem<T>> Items { get; set; }
}
