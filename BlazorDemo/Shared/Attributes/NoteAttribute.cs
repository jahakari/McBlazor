namespace BlazorDemo.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class NoteAttribute : Attribute
{
	public NoteAttribute(string note)
	{
        ArgumentException.ThrowIfNullOrEmpty(note, nameof(note));

        Note = note;
    }

    public string Note { get; }
}
