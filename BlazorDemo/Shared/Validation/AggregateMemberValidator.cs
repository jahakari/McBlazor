
namespace BlazorDemo.Shared.Validation;

public class AggregateMemberValidator : MemberValidator
{
    private readonly List<MemberValidator> validators;

    public AggregateMemberValidator(IEnumerable<MemberValidator> validators)
    {
        ArgumentNullException.ThrowIfNull(validators, nameof(validators));

        this.validators = validators.ToList();
    }

    public override async Task<string?> ValidateAsync(object? value)
    {
        foreach (MemberValidator validator in validators) {
            string? error = await validator.ValidateAsync(value);

            if (error is not null) {
                return error;
            }
        }

        return null;
    }
}
