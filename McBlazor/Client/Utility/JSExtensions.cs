using Microsoft.JSInterop;

namespace McBlazor.Client.Utility;

public static class JSExtensions
{
    public static ValueTask AlertAsync(this IJSRuntime jSRuntime, string message)
    {
        ArgumentNullException.ThrowIfNull(jSRuntime, nameof(JSRuntime));
        ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));

        return jSRuntime.InvokeVoidAsync("alert", message);
    }

    public static ValueTask<bool> ConfirmAsync(this IJSRuntime jSRuntime, string prompt)
    {
        ArgumentNullException.ThrowIfNull(jSRuntime, nameof(jSRuntime));
        ArgumentNullException.ThrowIfNullOrEmpty(prompt, nameof(prompt));

        return jSRuntime.InvokeAsync<bool>("confirm", prompt);
    }
}
