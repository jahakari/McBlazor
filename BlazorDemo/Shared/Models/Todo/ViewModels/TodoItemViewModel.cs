using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Shared.Models.Todo.ViewModels;

public record TodoItemViewModel
{
    public Guid Id { get; } = Guid.NewGuid();

    [Required, StringLength(50, MinimumLength = 5)]
    public string? Title { get; set; }

    [Required, StringLength(200, MinimumLength = 20)]
    public string? Description { get; set; }

    public TodoPriority Priority { get; set; } = TodoPriority.Normal;

    public bool IsComplete { get; set; }
}
