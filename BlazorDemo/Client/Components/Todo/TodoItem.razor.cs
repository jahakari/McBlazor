using BlazorDemo.Client.Utility;
using BlazorDemo.Shared.Models.Todo.ViewModels;
using BlazorDemo.Shared.Models.Todo;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using Microsoft.JSInterop;

namespace BlazorDemo.Client.Components.Todo;

public partial class TodoItem : ComponentBase
{
    private ItemState _state = ItemState.Default;

    private BootstrapTheme BorderTheme => _state switch
    {
        ItemState.Completing   => BootstrapTheme.Warning,
        ItemState.Deleting     => BootstrapTheme.Danger,
        _ when Item.IsComplete => BootstrapTheme.Success,
        _                      => BootstrapTheme.Primary
    };

    private BootstrapTheme PriorityTheme => Item.Priority switch
    {
        TodoPriority.Low    => BootstrapTheme.Success,
        TodoPriority.Normal => BootstrapTheme.Primary,
        TodoPriority.High   => BootstrapTheme.Warning,
        _                   => BootstrapTheme.Danger
    };

    [Parameter, EditorRequired]
    public TodoItemViewModel Item { get; set; } = null!;

    [Parameter, EditorRequired]
    public EventCallback<TodoItemViewModel> OnEdit { get; set; }

    [Parameter, EditorRequired]
    public EventCallback<TodoItemViewModel> OnDelete { get; set; }

    [Parameter, EditorRequired]
    public EventCallback<TodoItemViewModel> OnComplete { get; set; }

    [Parameter, EditorRequired]
    public bool Disable { get; set; }

    [Inject, EditorBrowsable(EditorBrowsableState.Never)]
    public IJSRuntime JSRuntime { get; set; } = default!;

    private Task EditButtonClickedAsync() => OnEdit.InvokeAsync(Item);

    private async Task DeleteButtonClickedAsync()
    {
        _state = ItemState.Deleting;
        await Task.Delay(10);

        if (await JSRuntime.ConfirmAsync("Are you sure you want to delete this Todo item?")) {
            await OnDelete.InvokeAsync(Item);
        }

        _state = ItemState.Default;
    }

    private async Task CompleteButtonClickedAsync()
    {
        _state = ItemState.Completing;
        await Task.Delay(10);

        if (await JSRuntime.ConfirmAsync("Complete this Todo item?")) {
            await OnComplete.InvokeAsync(Item);
        }

        _state = ItemState.Default;
    }

    private enum ItemState
    {
        Default,
        Deleting,
        Completing
    }
}
