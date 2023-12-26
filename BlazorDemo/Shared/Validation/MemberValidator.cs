using BlazorDemo.Shared.Utility;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BlazorDemo.Shared.Validation;

public abstract class MemberValidator
{
    public abstract Task<string?> ValidateAsync(object? value);

    public static MemberValidator Create(MemberMetadataProvider metadataProvider)
    {
        ArgumentNullException.ThrowIfNull(metadataProvider, nameof(metadataProvider));

        ValidationAttribute[] attributes = metadataProvider.MemberInfo
            .GetCustomAttributes<ValidationAttribute>()
            .ToArray();

        if (attributes.Length == 0) {
            return MemberNonValidator.Instance;
        }

        return new AttributeMemberValidator(attributes, metadataProvider.Label);
    }
}
