using BlazorDemo.Shared.Models.Todo.ViewModels;

namespace BlazorDemo.Client.Services.Interfaces;

public interface ITodoItemRepository
{
    Task<List<TodoItemViewModel>> GetItemsAsync();
    Task<bool> SaveItemAsync(TodoItemViewModel item);
    Task<bool> MarkItemCompleteAsync(int id);
    Task<bool> DeleteItemAsync(int id);
}
