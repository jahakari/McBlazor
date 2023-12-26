namespace McBlazor.Shared.Validation;

public class MemberNonValidator : MemberValidator
{
    private static MemberNonValidator? instance;
    public static MemberNonValidator Instance => instance ??= new();

    private MemberNonValidator() { }

    public override Task<string?> ValidateAsync(object? value) => Task.FromResult<string?>(null);
}
