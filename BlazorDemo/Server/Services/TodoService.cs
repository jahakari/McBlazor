using BlazorDemo.Data.Models;
using BlazorDemo.Data.Models.Tables;
using BlazorDemo.Server.Services.Interfaces;
using BlazorDemo.Server.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorDemo.Server.Services;

public class TodoService : ITodoService
{
    private readonly DemoContext db;

    public TodoService(DemoContext db) => this.db = db;

    public IQueryable<TodoItem> QueryAll() => db.TodoItems;

    public IQueryable<TProjection> QueryAll<TProjection>(Expression<Func<TodoItem, TProjection>> selector)
        => QueryAll().Select(selector);

    public Task UpsertAsync(TodoItem item)
    {
        db.TodoItems.Update(item);
        return db.SaveChangesAsync();
    }

    public Task CompleteAsync(int todoItemId)
        => db.TodoItems.Where(t => t.TodoItemId == todoItemId)
            .ExecuteUpdateAsync(s => s.SetProperty(t => t.IsComplete, true));

    public Task DeleteAsync(int todoItemId) => db.TodoItems.ExecuteDeleteAsync(t => t.TodoItemId == todoItemId);
}
