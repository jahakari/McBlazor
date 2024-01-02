using BlazorDemo.Data.Models.Tables;
using System.Linq.Expressions;

namespace BlazorDemo.Server.Services.Interfaces;

public interface ITodoService
{
    Task CompleteAsync(int todoItemId);
    Task DeleteAsync(int todoItemId);
    IQueryable<TodoItem> QueryAll();
    IQueryable<TProjection> QueryAll<TProjection>(Expression<Func<TodoItem, TProjection>> selector);
    Task UpsertAsync(TodoItem item);
}
