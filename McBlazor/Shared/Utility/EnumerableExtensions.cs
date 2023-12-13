namespace McBlazor.Shared.Utility;

public static class EnumerableExtensions
{
    public static List<T> ToList<T>(this IEnumerable<T> source, int capacity)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        if (capacity < 0) {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be a positive number");
        }

        var list = new List<T>(capacity);

        foreach (T item in source) {
            list.Add(item);
        }

        return list;
    }
}
