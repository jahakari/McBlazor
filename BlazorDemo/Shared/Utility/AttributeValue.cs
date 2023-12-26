namespace BlazorDemo.Shared.Utility;

public class AttributeValue<T>
{
    public AttributeValue(T? value) => Value = value;

    public T? Value { get; }
}
