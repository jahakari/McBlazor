using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

public partial class FormTextArea : FormEditorBase<string?>
{
    private Func<ChangeEventArgs, Task>? onChangeDelegate;
    private Func<ChangeEventArgs, Task>? onInputDelegate;

    [Parameter]
    public bool BindValueOnInput { get; set; }

    [Parameter]
    public int Rows { get; set; }

    protected override void OnInitialized()
    {
        if (BindValueOnInput) {
            onInputDelegate = EditorChangedAsync;
        }
        else {
            onChangeDelegate = EditorChangedAsync;
        }

        base.OnInitialized();
    }
}
