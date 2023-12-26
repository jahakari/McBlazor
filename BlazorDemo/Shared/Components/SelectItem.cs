namespace McBlazor.Shared.Components;

public class SelectItem<T>
{
    public SelectItem() { }

	public SelectItem(T value) : this(value?.ToString()!, value) { } 

	public SelectItem(string label, T value)
	{
        Label = label;
        Value = value;
    }

    public string Label { get; set; }
    public T Value { get; set; }
}
