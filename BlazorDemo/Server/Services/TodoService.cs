using BlazorDemo.Data.Models;
using BlazorDemo.Data.Models.Tables;
using BlazorDemo.Server.Services.Interfaces;
using BlazorDemo.Server.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorDemo.Server.Services;

public class TodoService : ITodoService
{
    private readonly DemoContext _db;

    public TodoService(DemoContext db) => _db = db;

    public IQueryable<TodoItem> QueryAll() => _db.TodoItems;

    public IQueryable<TProjection> QueryAll<TProjection>(Expression<Func<TodoItem, TProjection>> selector)
        => QueryAll().Select(selector);

    public Task UpsertAsync(TodoItem item)
    {
        _db.TodoItems.Update(item);
        return _db.SaveChangesAsync();
    }

    public Task CompleteAsync(int todoItemId)
        => _db.TodoItems.Where(t => t.TodoItemId == todoItemId)
            .ExecuteUpdateAsync(s => s.SetProperty(t => t.IsComplete, true));

    public Task DeleteAsync(int todoItemId) => _db.TodoItems.ExecuteDeleteAsync(t => t.TodoItemId == todoItemId);
}
