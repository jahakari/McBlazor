﻿using Microsoft.JSInterop;

namespace BlazorDemo.Client.Utility;

public static class JSExtensions
{
    public static ValueTask AlertAsync(this IJSRuntime jSRuntime, string message)
    {
        ArgumentNullException.ThrowIfNull(jSRuntime, nameof(jSRuntime));
        ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));

        return jSRuntime.InvokeVoidAsync("alert", message);
    }

    public static ValueTask<bool> ConfirmAsync(this IJSRuntime jSRuntime, string prompt)
    {
        ArgumentNullException.ThrowIfNull(jSRuntime, nameof(jSRuntime));
        ArgumentException.ThrowIfNullOrEmpty(prompt, nameof(prompt));

        return jSRuntime.InvokeAsync<bool>("confirm", prompt);
    }

    public static ValueTask SetLocalStorageItemAsync<T>(this IJSRuntime jSRuntime, string key, T item)
        => jSRuntime.InvokeVoidAsync("setLocalStorageItem", key, item);

    public static ValueTask<T> GetLocalStorageItemAsync<T>(this IJSRuntime jSRuntime, string key)
        => jSRuntime.InvokeAsync<T>("getLocalStorageItem", key);
}
