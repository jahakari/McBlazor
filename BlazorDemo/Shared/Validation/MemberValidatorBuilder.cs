using BlazorDemo.Shared.Utility;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BlazorDemo.Shared.Validation;

public class MemberValidatorBuilder
{
    private readonly List<MemberValidator> _validators = new();

    public MemberValidatorBuilder WithAttributeValidation(MemberMetadataProvider? metadataProvider, string? displayName)
    {
        if (metadataProvider is not null && TryCreateAttributeMemberValidator(metadataProvider, displayName, out AttributeMemberValidator? validator)) {
            _validators.Add(validator!);
        }

        return this;
    }

    public MemberValidatorBuilder WithCustomValidation(Func<object?, Task<string?>>? validationDelegate)
    {
        if (validationDelegate is not null) {
            _validators.Add(new CustomMemberValidator(validationDelegate));
        }

        return this;
    }

    public MemberValidatorBuilder WithValidators(IEnumerable<MemberValidator>? validators)
    {
        if (validators is not null) {
            this._validators.AddRange(validators);
        }

        return this;
    }

    public MemberValidator Build()
    {
        return _validators switch
        {
            []                  => MemberNonValidator.Instance,
            [MemberValidator v] => v,
            _                   => new AggregateMemberValidator(_validators)
        };
    }

    private static bool TryCreateAttributeMemberValidator(MemberMetadataProvider metadataProvider, string? displayName, out AttributeMemberValidator? validator)
    {
        ValidationAttribute[] attributes = metadataProvider.MemberInfo
            .GetCustomAttributes<ValidationAttribute>()
            .ToArray();

        if (attributes.Length == 0) {
            validator = null;
            return false;
        }

        displayName ??= metadataProvider.Label ?? metadataProvider.MemberInfo.Name;

        validator = new AttributeMemberValidator(attributes, displayName);
        return true;
    }
}
