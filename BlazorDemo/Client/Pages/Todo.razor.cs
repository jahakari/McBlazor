using BlazorDemo.Client.Components;
using BlazorDemo.Shared.Components;
using BlazorDemo.Shared.Models.Todo;
using BlazorDemo.Shared.Models.Todo.ViewModels;
using BlazorDemo.Shared.Utility;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Pages;

public partial class Todo : ComponentBase
{
    private readonly TodoPlaceholders[] _placeholders =
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

    private int _currentPlaceholderIndex = 0;
    private TodoPlaceholders _currentPlaceholders => _placeholders[_currentPlaceholderIndex];

    private readonly List<TodoItemViewModel> _items = new();
    private TodoItemViewModel _editingItem = new();
    private bool _isEditing;
    
    private readonly List<SelectItem<TodoPriority>> _priorityItems = FormHelpers.CreateSelectItems<TodoPriority>();
    private FormValidator _validator = null!;

    protected override void OnInitialized()
    {
        Random.Shared.Shuffle(_placeholders);
        base.OnInitialized();
    }

    private void EditItem(TodoItemViewModel item)
    {
        _editingItem = item with { };
        _isEditing = true;
    }

    private void CancelEditing()
    {
        if (!string.IsNullOrWhiteSpace(_editingItem.Title) && !string.IsNullOrWhiteSpace(_editingItem.Description)) {
            UpdatePlaceholders();
        }

        _editingItem = new();
        _isEditing = false;
    }

    private async Task SaveItemAsync()
    {
        if (!await _validator.ValidateAsync()) {
            return;
        }

        if (_isEditing) {
            _items.Replace(i => i!.Id == _editingItem.Id, _editingItem);
        } else {
            _items.Add(_editingItem);
        }

        CancelEditing();
    }

    private Task DeleteItemAsync(TodoItemViewModel item)
    {
        _items.Remove(item);
        return Task.CompletedTask;
    }

    private Task CompleteItemAsync(TodoItemViewModel item)
    {
        item.IsComplete = true;
        return Task.CompletedTask;
    }

    private void UpdatePlaceholders()
    {
        if (_currentPlaceholderIndex + 1 < _placeholders.Length) {
            _currentPlaceholderIndex++;
        } else {
            _currentPlaceholderIndex = 0;
        }
    }

    private record TodoPlaceholders(string Title, string Description);
}
