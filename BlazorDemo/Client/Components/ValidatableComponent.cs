using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

public abstract class ValidatableComponent : ComponentBase, IDisposable
{
    protected string? _validationError;
    protected string? ValidationClass => _validationError is null ? null : "invalid";

    [CascadingParameter]
    public FormValidator? Validator { get; set; }

    protected override void OnInitialized() => Validator?.AddComponent(this);

    protected abstract Task<string?> GetValidationErrorAsync();

    public async Task<bool> ValidateAsync()
    {
        _validationError = await GetValidationErrorAsync();
        return _validationError is null;
    }

    public async Task<bool> IsValidAsync() => await GetValidationErrorAsync() is null;

    public void Dispose() => Validator?.RemoveComponent(this);
}