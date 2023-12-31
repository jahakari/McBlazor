using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Shared.Validation;

public class AttributeMemberValidator : MemberValidator
{
    private readonly ValidationAttribute[] validationAttributes;
    private readonly string displayName;

    public AttributeMemberValidator(ValidationAttribute[] validationAttributes, string displayName)
    {
        ArgumentNullException.ThrowIfNull(validationAttributes, nameof(validationAttributes));
        ArgumentException.ThrowIfNullOrWhiteSpace(displayName, nameof(displayName));

        this.validationAttributes = validationAttributes;
        this.displayName = displayName;
    }

    public override Task<string?> ValidateAsync(object? value)
    {
        string? error = validationAttributes.FirstOrDefault(v => !v.IsValid(value))?.FormatErrorMessage(displayName);
        return Task.FromResult(error);
    }
}
