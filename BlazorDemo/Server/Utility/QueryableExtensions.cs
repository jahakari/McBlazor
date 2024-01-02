using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorDemo.Server.Utility;

public static class QueryableExtensions
{
    public static Task<int> ExecuteDeleteAsync<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        => source.Where(predicate).ExecuteDeleteAsync(cancellationToken);
}
