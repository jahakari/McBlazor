namespace BlazorDemo.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class TitleAttribute : Attribute
{
	public TitleAttribute(string title)
	{
        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

        Title = title;
    }

    public string Title { get; }
}
