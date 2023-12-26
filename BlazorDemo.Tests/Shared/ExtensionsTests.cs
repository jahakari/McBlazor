using BlazorDemo.Shared.Utility;
using BlazorDemo.Tests.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlazorDemo.Tests.Shared;

[TestClass]
public class ExtensionsTests
{
    [TestMethod, ShouldThrow<ArgumentNullException>]
    public void IEnumerableOfT_ToList_Should_Throw_When_Source_Is_Null()
    {
        IEnumerable<string> source = null!;

        source.ToList(3);
    }

    [TestMethod, ShouldThrow<ArgumentOutOfRangeException>]
    public void IEnumerableOfT_ToList_Should_Throw_When_Capacity_Is_Negative() => new string[1].ToList(-1);

    [TestMethod]
    public void IEnumerableOfT_ToList_Should_Return_List_With_All_Items()
    {
        int[] items = [1, 2, 3];

        List<int> actual = items.ToList(items.Length);

        Assert.AreEqual(items.Length, actual.Capacity);
        CollectionAssert.AreEquivalent(items, actual);
    }
}
