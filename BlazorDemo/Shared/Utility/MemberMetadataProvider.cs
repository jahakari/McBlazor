using BlazorDemo.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace BlazorDemo.Shared.Utility;

public class MemberMetadataProvider
{
    public MemberMetadataProvider(MemberInfo memberInfo) => MemberInfo = memberInfo;

    public MemberInfo MemberInfo { get; }

    private AttributeValue<string?>? _label;
    public string Label 
        => (_label ??= MemberInfo.GetAttributeValueOrDefault<LabelAttribute, string>(a => a.Label, MemberInfo.Name)).Value!;

    private AttributeValue<string?>? _note;
    public string? Note => (_note ??= MemberInfo.GetAttributeValueOrDefault<NoteAttribute, string>(a => a.Note)).Value;

    private AttributeValue<string?>? _title;
    public string? Title => (_title ??= MemberInfo.GetAttributeValueOrDefault<TitleAttribute, string>(a => a.Title)).Value;

    private AttributeValue<string?>? _placeholder;
    public string? Placeholder => (_placeholder ??= MemberInfo.GetAttributeValueOrDefault<PlaceholderAttribute, string>(a => a.Placeholder)).Value;

    private bool? _hasRequiredAttribute;
    public bool HasRequiredAttribute => _hasRequiredAttribute ??= MemberInfo.IsDefined(typeof(RequiredAttribute));

    public static MemberMetadataProvider Create<T>(Expression<Func<T?>> memberExpression)
    {
        MemberInfo memberInfo = ExpressionHelpers.GetMemberInfo(memberExpression);
        return new MemberMetadataProvider(memberInfo);
    }
}
