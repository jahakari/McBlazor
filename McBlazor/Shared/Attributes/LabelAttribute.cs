namespace McBlazor.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class LabelAttribute : Attribute
{
	public LabelAttribute() { }

    public LabelAttribute(string label)
    {
        ArgumentException.ThrowIfNullOrEmpty(label, nameof(label));

        Label = label;
    }

    public string Label { get; }
}
