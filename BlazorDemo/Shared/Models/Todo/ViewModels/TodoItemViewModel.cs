using BlazorDemo.Data.Models;
using BlazorDemo.Data.Models.Tables;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BlazorDemo.Shared.Models.Todo.ViewModels;

public record TodoItemViewModel
{
    public int TodoItemId { get; set; }

    [Required, StringLength(50, MinimumLength = 5)]
    public string? Title { get; set; }

    [Required, StringLength(200, MinimumLength = 20)]
    public string? Description { get; set; }

    public TodoPriority Priority { get; set; } = TodoPriority.Normal;

    public bool IsComplete { get; set; }

    public TodoItem ToEntity()
    {
        return new TodoItem
        {
            TodoItemId = this.TodoItemId,
            Title = this.Title ?? throw new InvalidOperationException("Title may not be null."),
            Description = this.Description ?? throw new InvalidOperationException("Description may not be null."),
            Priority = this.Priority,
            IsComplete = this.IsComplete
        };
    }

    public static Expression<Func<TodoItem, TodoItemViewModel>> Selector { get; }
        = t => new TodoItemViewModel
        {
            TodoItemId = t.TodoItemId,
            Title = t.Title,
            Description = t.Description,
            Priority = t.Priority,
            IsComplete = t.IsComplete
        };
}