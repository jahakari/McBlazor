namespace BlazorDemo.Client.Utility;

public class ApiResult<T>
{
    public ApiResult() { }

	public ApiResult(T? value)
	{
        Success = true;
        Value = value;
    }

    public bool Success { get; }
    public T? Value { get; }
}
