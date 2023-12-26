using BlazorDemo.Shared.Components;

namespace BlazorDemo.Shared.Utility;

public static class FormHelpers
{
    public static List<SelectItem<T>> CreateSelectItems<T>(T item)
        => new List<SelectItem<T>>(1) { new(item) };
    public static List<SelectItem<T>> CreateSelectItems<T>(T item1, T item2)
        => new List<SelectItem<T>>(2) { new(item1), new(item2) };
    public static List<SelectItem<T>> CreateSelectItems<T>(T item1, T item2, T item3)
        => new List<SelectItem<T>>(3) { new(item1), new(item2), new(item3) };
    public static List<SelectItem<T>> CreateSelectItems<T>(T item1, T item2, T item3, T item4)
        => new List<SelectItem<T>>(4) { new(item1), new(item2), new(item3), new(item4) };

    public static List<SelectItem<T>> CreateSelectItems<T>(params T[] values)
    {
        ArgumentNullException.ThrowIfNull(values, nameof(values));
        return values.Select(v => new SelectItem<T>(v)).ToList(values.Length);
    }

    public static List<SelectItem<T>> CreateSelectItems<T>() where T : struct, Enum
        => CreateSelectItems(Enum.GetValues<T>());
}
