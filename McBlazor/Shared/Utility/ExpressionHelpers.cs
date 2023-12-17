using System.Linq.Expressions;
using System.Reflection;

namespace McBlazor.Shared.Utility;

public static class ExpressionHelpers
{
    public static MemberInfo GetMemberInfo<T>(Expression<Func<T?>> expression)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        return expression.Body switch
        {
            MemberExpression m => m.Member,
            UnaryExpression u
                when u.Operand is MemberExpression m => m.Member,
            _ => throw new ArgumentException("Expression does not represent member access.", nameof(expression))
        };
    }
}
