using BlazorDemo.Shared.Attributes;
using System.Linq.Expressions;
using System.Reflection;

namespace BlazorDemo.Shared.Utility;

public class MemberMetadataProvider
{
    public MemberMetadataProvider(MemberInfo memberInfo) => MemberInfo = memberInfo;

    public MemberInfo MemberInfo { get; }

    private AttributeValue<string?>? label;
    public string Label 
        => (label ??= MemberInfo.GetAttributeValueOrDefault<LabelAttribute, string>(a => a.Label, MemberInfo.Name)).Value!;

    private AttributeValue<string?>? note;
    public string? Note => (note ??= MemberInfo.GetAttributeValueOrDefault<NoteAttribute, string>(a => a.Note)).Value;

    private AttributeValue<string?>? title;
    public string? Title => (title ??= MemberInfo.GetAttributeValueOrDefault<TitleAttribute, string>(a => a.Title)).Value;

    private AttributeValue<string?>? placeholder;
    public string? Placeholder => (placeholder ??= MemberInfo.GetAttributeValueOrDefault<PlaceholderAttribute, string>(a => a.Placeholder)).Value;

    public static MemberMetadataProvider Create<T>(Expression<Func<T?>> memberExpression)
    {
        MemberInfo memberInfo = ExpressionHelpers.GetMemberInfo(memberExpression);
        return new MemberMetadataProvider(memberInfo);
    }
}
