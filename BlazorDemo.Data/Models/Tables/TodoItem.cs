using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorDemo.Data.Models.Tables;

public class TodoItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TodoItemId { get; set; }

    [Required, MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public TodoPriority Priority { get; set; }

    [Required]
    public bool IsComplete { get; set; }
}

public class TodoItemEntityTypeConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable(nameof(TodoItem), "dbo");
        builder.HasKey(t => t.TodoItemId);
    }
}