namespace BlazorDemo.Shared.Validation;

public interface IMemberValidator
{
    string? Validate(object? value);
}
