using McBlazor.Client.Components;
using McBlazor.Client.Utility;
using McBlazor.Shared.Components;
using McBlazor.Shared.Models.Todo;
using McBlazor.Shared.Models.Todo.ViewModels;
using McBlazor.Shared.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace McBlazor.Client.Pages;

public partial class Todo : ComponentBase
{
    private readonly TodoPlaceholders[] placeholders =
    [
        new("Feed the dog", "Fluffy isn't going to feed himself!"),
        new("Walk the dog", "Fluffy isn't going to walk himself!"),
        new("Wash the car", "It's getting hard to see out the windows..."),
        new("Read a book", "Free your mind for a bit..."),
        new("Eat more fruit", "You're about 5 servings behind the daily recommendation."),
        new("Vacuum the house", "I can see footprints in the dust..."),
        new("Do the dishes", "Step 1: find the sink..."),
        new("Find new music", "I recommend \"Iron Maiden\"."),
        new("Exercise", "Or don't.  It's your well-being, not mine..."),
        new("Mow the lawn", "It's getting hard to see out the windows..."),
        new("Take out the papers and the trash", "\"Or you won't get no spending cash!\""),
        new("Learn another language", "Sólo hablo un poco de español...")
    ];

    private TodoPlaceholders currentPlaceholders = new(string.Empty, string.Empty);
    private readonly Random random = new();

    private List<TodoItemViewModel> items = new();
    private TodoItemViewModel editingItem = new();
    private bool isEditing;
    
    private readonly List<SelectItem<TodoPriority>> priorityItems = FormHelpers.CreateSelectItems<TodoPriority>();
    private FormValidator validator = null!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    protected override void OnInitialized()
    {
        UpdatePlaceholders();
        base.OnInitialized();
    }

    private void EditItem(TodoItemViewModel item)
    {
        editingItem = item with { };
        isEditing = true;
    }

    private void CancelEditing()
    {
        if (!string.IsNullOrWhiteSpace(editingItem.Title) && !string.IsNullOrWhiteSpace(editingItem.Description)) {
            UpdatePlaceholders();
        }

        editingItem = new();
        isEditing = false;
    }

    private Task<string?> ValidateTitleAsync()
    {
        if (string.IsNullOrWhiteSpace(editingItem.Title)) {
            return Task.FromResult("Title is required")!;
        }

        return Task.FromResult<string?>(null);
    }

    private async Task SaveItemAsync()
    {
        if (!await validator.ValidateAsync()) {
            return;
        }

        if (isEditing) {
            items.Replace(i => i!.Id == editingItem.Id, editingItem);
        } else {
            items.Add(editingItem);
        }

        CancelEditing();
    }

    private async Task DeleteItemAsync(TodoItemViewModel item)
    {
        if (await JSRuntime.ConfirmAsync("Are you sure you want to delete this Todo item?")) {
            items.Remove(item);
        }
    }

    private void UpdatePlaceholders()
    {
        int retries = 3;

        while (retries > 0) {
            TodoPlaceholders newPlaceholders = placeholders[random.Next(0, placeholders.Length)];

            if (currentPlaceholders != newPlaceholders) {
                currentPlaceholders = newPlaceholders;
                return;
            }

            retries--;
        }
    }

    private record TodoPlaceholders(string Title, string Description);
}
