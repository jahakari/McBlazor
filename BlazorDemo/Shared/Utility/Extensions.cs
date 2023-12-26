namespace BlazorDemo.Shared.Utility;

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

    public static bool TryAdd<T>(this List<T> list, T item)
    {
        ArgumentNullException.ThrowIfNull(list, nameof(list));

        if (list.Contains(item)) {
            return false;
        }

        list.Add(item);
        return true;
    }

    public static async Task<bool> EveryAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));

        bool result = true;

        foreach (T item in source) {
            result &= await predicate(item);
        }

        return result;
    }

    public static async Task<bool> AllAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));

        foreach (T item in source) {
            if (!await predicate(item)) {
                return false;
            }
        }

        return true;
    }
}
