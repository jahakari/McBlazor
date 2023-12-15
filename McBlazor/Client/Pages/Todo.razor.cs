using McBlazor.Client.Utility;
using McBlazor.Shared.Components;
using McBlazor.Shared.Models.Todo;
using McBlazor.Shared.Models.Todo.ViewModels;
using McBlazor.Shared.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace McBlazor.Client.Pages;

public partial class Todo : ComponentBase
{
    private List<TodoItemViewModel> items = new();
    private TodoItemViewModel editingItem = new();
    
    private bool isEditing;

    private List<SelectItem<TodoPriority>> priorityItems = FormHelpers.CreateSelectItems<TodoPriority>();

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    private void EditItem(TodoItemViewModel item)
    {
        editingItem = item with { };
        isEditing = true;
    }

    private void CancelEditing()
    {
        editingItem = new();
        isEditing = false;
    }

    private void SaveItem()
    {
        if (isEditing) {
            items.Replace(i => i.Id == editingItem.Id, editingItem);
        } else {
            items.Add(editingItem);
        }

        CancelEditing();
    }

    private async Task DeleteItemAsync(TodoItemViewModel item)
    {
        if (await JSRuntime.ConfirmAsync("Are you sure you want to delete this Todo item?")) {
            items.Remove(item);
        }
    }
}
