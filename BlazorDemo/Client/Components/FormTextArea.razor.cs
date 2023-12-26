using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

/// <summary>
/// Renders an Html &lt;textarea&gt; control.
/// </summary>
public partial class FormTextArea : FormEditorBase<string?>
{
    private Func<ChangeEventArgs, Task>? onChangeDelegate;
    private Func<ChangeEventArgs, Task>? onInputDelegate;

    /// <summary>
    /// When <see langword="true" />, binds the input contents to the underlying component value after each key press.
    /// Default is <see langword="false" />, which binds the input contents when it loses focus.
    /// </summary>
    [Parameter]
    public bool BindValueOnInput { get; set; }

    /// <summary>
    /// The initial number of text rows in the textarea.
    /// </summary>
    [Parameter]
    public int Rows { get; set; } = 2;

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
