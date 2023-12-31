
namespace BlazorDemo.Shared.Validation;

public class CustomMemberValidator : MemberValidator
{
    private readonly Func<object?, Task<string?>> validationDelegate;

    public CustomMemberValidator(Func<object?, Task<string?>> validationDelegate)
    {
        ArgumentNullException.ThrowIfNull(validationDelegate, nameof(validationDelegate));

        this.validationDelegate = validationDelegate;
    }

    public override Task<string?> ValidateAsync(object? value) => validationDelegate(value);
}
