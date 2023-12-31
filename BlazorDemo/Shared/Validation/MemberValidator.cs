namespace BlazorDemo.Shared.Validation;

public abstract class MemberValidator
{
    public abstract Task<string?> ValidateAsync(object? value);
}
