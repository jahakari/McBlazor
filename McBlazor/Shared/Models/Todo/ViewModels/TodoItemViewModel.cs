using McBlazor.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace McBlazor.Shared.Models.Todo.ViewModels;

public record TodoItemViewModel
{
    public Guid Id { get; } = Guid.NewGuid();

    [Required(ErrorMessage = "This is required, you degenerate."), Placeholder("Feed the Dog")]
    public string? Title { get; set; }

    [Required, Placeholder("Fluffy is hungry and needs kibble!")]
    public string? Description { get; set; }

    public TodoPriority Priority { get; set; } = TodoPriority.Normal;
}
