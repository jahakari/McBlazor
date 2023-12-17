using Microsoft.AspNetCore.Components;

namespace McBlazor.Client.Components;

public abstract class ValidatableComponent : ComponentBase, IDisposable
{
    protected string? validationError;
    protected string? ValidationClass => validationError is null ? null : "invalid";

    [CascadingParameter]
    public FormValidator? Validator { get; set; }

    [Parameter]
    public Func<Task<string?>>? CustomValidator { get; set; }

    protected override void OnInitialized() => Validator?.AddComponent(this);

    protected abstract Task<string?> ValidateInternalAsync();

    public async Task<bool> ValidateAsync()
    {
        validationError = await ValidateInternalAsync();

        if (validationError is null && CustomValidator is not null) {
            validationError = await CustomValidator();
        }

        return validationError is null;
    }

    public async Task<bool> IsValidAsync() => await ValidateInternalAsync() is null;

    public void Dispose() => Validator?.RemoveComponent(this);
}

public abstract class ValidatableComponent<T> : ValidatableComponent
{

}