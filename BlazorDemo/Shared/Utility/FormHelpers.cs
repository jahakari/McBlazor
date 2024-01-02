using BlazorDemo.Shared.Components;

namespace BlazorDemo.Shared.Utility;

public static class FormHelpers
{
    /// <summary>
    /// Creates a list of <see cref="SelectItem{T}" />s using the specified value.
    /// </summary>
    public static List<SelectItem<T>> CreateSelectItems<T>(T item) => [new(item)];

    /// <summary>
    /// Creates a list of <see cref="SelectItem{T}" />s using the specified values.
    /// </summary>
    public static List<SelectItem<T>> CreateSelectItems<T>(T item1, T item2) => [new(item1), new(item2)];

    /// <summary>
    /// Creates a list of <see cref="SelectItem{T}" />s using the specified values.
    /// </summary>
    public static List<SelectItem<T>> CreateSelectItems<T>(T item1, T item2, T item3) => [new(item1), new(item2), new(item3)];

    /// <summary>
    /// Creates a list of <see cref="SelectItem{T}" />s using the specified values.
    /// </summary>
    public static List<SelectItem<T>> CreateSelectItems<T>(T item1, T item2, T item3, T item4) => [new(item1), new(item2), new(item3), new(item4)];

    /// <summary>
    /// Creates a list of <see cref="SelectItem{T}" />s using the specified values.
    /// </summary>
    public static List<SelectItem<T>> CreateSelectItems<T>(params T[] values)
    {
        ArgumentNullException.ThrowIfNull(values, nameof(values));
        return values.Select(v => new SelectItem<T>(v)).ToList(values.Length);
    }

    /// <summary>
    /// Creates a list of <see cref="SelectItem{T}" />s using the specified enum type.
    /// </summary>
    public static List<SelectItem<T>> CreateSelectItems<T>() where T : struct, Enum
        => CreateSelectItems(Enum.GetValues<T>());
}
