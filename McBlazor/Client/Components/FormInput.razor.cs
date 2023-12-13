using McBlazor.Client.Utility;
using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

public partial class FormInput<T> : FormEditorBase<T>
{
    private string? inputType;
    private Func<ChangeEventArgs, Task>? onChangeDelegate;
    private Func<ChangeEventArgs, Task>? onInputDelegate;

    [Parameter]
    public bool BindValueOnInput { get; set; }

    protected override void OnInitialized()
    {
        if (!EditorHelpers.TryGetInputType<T>(out inputType)) {
            throw new Exception($"Input type could not be determined for Type '{typeof(T)}'.");
        }

        if (BindValueOnInput) {
            onInputDelegate = EditorChangedAsync;
        } else {
            onChangeDelegate = EditorChangedAsync;
        }

        base.OnInitialized();
    }
}
