using BlazorDemo.Client.Services.Interfaces;
using BlazorDemo.Client.Utility;
using BlazorDemo.Shared.Models.Todo.ViewModels;
using BlazorDemo.Shared.Utility;
using Microsoft.JSInterop;

namespace BlazorDemo.Client.Services;

public class LocalTodoItemRepository : ITodoItemRepository
{
    private const string localStorageKey = "todo_items";

    private readonly IJSRuntime jSRuntime;

    public LocalTodoItemRepository(IJSRuntime jSRuntime) => this.jSRuntime = jSRuntime;

    public async Task<bool> DeleteItemAsync(int id)
    {
        List<TodoItemViewModel> items = await GetItemsAsync();
        bool deleted = items.TryRemove(i => i!.TodoItemId == id);

        await UpdateLocalStorageAsync(items, deleted);
        return deleted;
    }

    public async Task<List<TodoItemViewModel>> GetItemsAsync()
        => await jSRuntime.GetLocalStorageItemAsync<List<TodoItemViewModel>>(localStorageKey) ?? [];

    public async Task<bool> MarkItemCompleteAsync(int id)
    {
        List<TodoItemViewModel> items = await GetItemsAsync();
        bool completed = items.TryUpdate(i => i!.TodoItemId == id, i => i.IsComplete = true);

        await UpdateLocalStorageAsync(items, completed);
        return completed;
    }

    public async Task<bool> SaveItemAsync(TodoItemViewModel item)
    {
        List<TodoItemViewModel> items = await GetItemsAsync();
        bool saved = false;

        if (item.TodoItemId == default) {
            item.TodoItemId = (items.MaxBy(i => i.TodoItemId)?.TodoItemId ?? 0) + 1;
            items.Add(item);
            saved = true;
        }
        else {
            saved = items.TryReplace(i => i!.TodoItemId == item.TodoItemId, item);
        }

        await UpdateLocalStorageAsync(items, saved);
        return saved;
    }

    private ValueTask UpdateLocalStorageAsync(List<TodoItemViewModel> items, bool doUpdate)
    {
        if (doUpdate) {
            return jSRuntime.SetLocalStorageItemAsync(localStorageKey, items);
        }

        return ValueTask.CompletedTask;
    }
}
