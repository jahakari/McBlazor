﻿using BlazorDemo.Client.Utility;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

/// <summary>
/// Renders an Html &lt;input /&gt; control.
/// </summary>
/// <typeparam name="T">The type of data bound to this component.</typeparam>
public partial class FormInput<T> : FormEditorBase<T>
{
    private string? inputType;
    private Func<ChangeEventArgs, Task>? onChangeDelegate;
    private Func<ChangeEventArgs, Task>? onInputDelegate;

    /// <summary>
    /// When <see langword="true" />, binds the input contents to the underlying component value after each key press.
    /// Default is <see langword="false" />, which binds the input contents when it loses focus or the "Enter" key is pressed.
    /// </summary>
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
