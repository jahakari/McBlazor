
namespace McBlazor.Tests.Utility;

public class ShouldThrowAttribute<TException> : ExpectedExceptionBaseAttribute where TException : Exception
{
    protected override void Verify(Exception exception) => Assert.IsInstanceOfType<TException>(exception);
}
