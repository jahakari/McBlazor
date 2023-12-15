using McBlazor.Client.Utility;
using McBlazor.Shared.Models.Todo.ViewModels;
using McBlazor.Shared.Models.Todo;
using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components.Todo;

public partial class TodoItem : ComponentBase
{
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
    public bool Disable { get; set; }

    private Task EditButtonClickedAsync() => OnEdit.InvokeAsync(Item);

    private Task DeleteButtonClickedAsync() => OnDelete.InvokeAsync(Item);
}
