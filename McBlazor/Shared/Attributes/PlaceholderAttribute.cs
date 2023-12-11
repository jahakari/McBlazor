namespace McBlazor.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class PlaceholderAttribute : Attribute
{
	public PlaceholderAttribute(string placeholder)
	{
        ArgumentException.ThrowIfNullOrEmpty(placeholder, nameof(placeholder));

        Placeholder = placeholder;
    }

    public string Placeholder { get; }
}
