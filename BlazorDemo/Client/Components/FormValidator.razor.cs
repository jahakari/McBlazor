using BlazorDemo.Shared.Utility;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

public partial class FormValidator : ComponentBase
{
    private readonly List<ValidatableComponent> _components = new();

    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;

    public void AddComponent(ValidatableComponent component)
    {
        if (!_components.TryAdd(component)) {
            throw new ArgumentException("Component has already been added.", nameof(component));
        }
    }

    public void RemoveComponent(ValidatableComponent component) => _components.Remove(component);

    public Task<bool> ValidateAsync() => _components.EveryAsync(c => c.ValidateAsync());

    public Task<bool> IsValidAsync() => _components.AllAsync(c => c.IsValidAsync());
}