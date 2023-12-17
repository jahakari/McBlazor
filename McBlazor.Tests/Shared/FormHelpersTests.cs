using McBlazor.Shared.Components;
using McBlazor.Shared.Utility;

namespace McBlazor.Tests.Shared;

[TestClass]
public class FormHelpersTests
{
    [TestMethod]
    public void CreateSelectItems_Should_Create_Single_Item()
    {
        List<SelectItem<string>> items = FormHelpers.CreateSelectItems("Foo");

        Assert.AreEqual(1, items.Count);
        AssertSelectItemEqual("Foo", items[0]);
    }

    [TestMethod]
    public void CreateSelectItems_Should_Create_2_Items()
    {
        string[] values = ["Foo", "Bar"];

        List<SelectItem<string>> items = FormHelpers.CreateSelectItems(values[0], values[1]);

        AssertAllSelectItemsEqual(values, items);
    }

    [TestMethod]
    public void CreateSelectItems_Should_Create_3_Items()
    {
        string[] values = ["Foo", "Bar", "Baz"];

        List<SelectItem<string>> items = FormHelpers.CreateSelectItems(values[0], values[1], values[2]);

        AssertAllSelectItemsEqual(values, items);
    }

    [TestMethod]
    public void CreateSelectItems_Should_Create_4_Items()
    {
        string[] values = ["Foo", "Bar", "Baz", "Bat"];

        List<SelectItem<string>> items = FormHelpers.CreateSelectItems(values[0], values[1], values[2], values[3]);

        AssertAllSelectItemsEqual(values, items);
    }

    [TestMethod]
    public void CreateSelectItems_Should_Create_Multiple_Items()
    {
        string[] values = ["Foo", "Bar", "Baz", "Bat", "Fizz", "Buzz"];

        List<SelectItem<string>> items = FormHelpers.CreateSelectItems(values);

        AssertAllSelectItemsEqual(values, items);
    }

    [TestMethod]
    public void CreateSelectItems_Should_Create_Items_From_Enum()
    {
        TestEnum[] values = [TestEnum.Foo, TestEnum.Bar, TestEnum.Baz];

        List<SelectItem<TestEnum>> items = FormHelpers.CreateSelectItems<TestEnum>();

        AssertAllSelectItemsEqual(values, items);
    }

    private static void AssertSelectItemEqual<TValue>(TValue expected, SelectItem<TValue> item)
    {
        Assert.AreEqual(expected!.ToString(), item.Label);
        Assert.AreEqual(expected, item.Value);
    }

    private static void AssertAllSelectItemsEqual<TValue>(TValue[] expected, List<SelectItem<TValue>> items)
    {
        Assert.AreEqual(expected.Length, items.Count);

        for (int i = 0; i < expected.Length; i++) {
            AssertSelectItemEqual(expected[i], items[i]);
        }
    }
}

public enum TestEnum
{
    Foo,
    Bar,
    Baz
}
