using System.ComponentModel.DataAnnotations;

namespace McBlazor.Shared.Models.Todo.ViewModels;

public record TodoItemViewModel
{
    public Guid Id { get; } = Guid.NewGuid();

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    public TodoPriority Priority { get; set; } = TodoPriority.Normal;
}
