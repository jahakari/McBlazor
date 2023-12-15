namespace McBlazor.Shared.Utility;

public static class Extensions
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

    public static void Replace<T>(this List<T> list, Predicate<T?> predicate, T replacementItem)
    {
        ArgumentNullException.ThrowIfNull(list, nameof(list));
        ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));

        int index = list.FindIndex(predicate);

        if (index < 0) {
            return;
        }

        list[index] = replacementItem;
    }
}
