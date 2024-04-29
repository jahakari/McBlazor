using BlazorDemo.Client.Services.Interfaces;
using BlazorDemo.Shared.Models.Todo.ViewModels;

namespace BlazorDemo.Client.Services;

public class RemoteTodoItemRepository : ITodoItemRepository
{
    private readonly IApiService api;

    public RemoteTodoItemRepository(IApiService api) => this.api = api;

    public Task<bool> DeleteItemAsync(int id) => api.DeleteAsync($"Todo/Delete?todoItemId={id}");

    public async Task<List<TodoItemViewModel>> GetItemsAsync()
        => (await api.GetAsync<List<TodoItemViewModel>>("Todo/GetAll")).Value ?? [];

    public Task<bool> MarkItemCompleteAsync(int id) => api.GetAsync($"Todo/Complete?todoItemId={id}");

    public Task<bool> SaveItemAsync(TodoItemViewModel item) => api.PostAsync("Todo/CreateOrUpdate", item);
}
