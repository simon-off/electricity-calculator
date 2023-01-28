using ElectricityCalculator.Classes;

public class ItemDataTest
{
    [Theory]
    [InlineData(1000, 4, ItemTimeFormat.Hours, 40)]
    [InlineData(1000, 1.5, ItemTimeFormat.Hours, 15)]
    [InlineData(1000, 25, ItemTimeFormat.Hours, 240)]
    [InlineData(1000, -1, ItemTimeFormat.Hours, 0)]
    [InlineData(1000, 1500, ItemTimeFormat.Minutes, 240)]
    [InlineData(1000, 1.5, ItemTimeFormat.Minutes, 0.25)]
    public void UpdateItemTest(
        double wattage,
        double usageTime,
        ItemTimeFormat timeFormat,
        double expected
    )
    {
        ItemList list = new();
        ItemData item = new(list);

        list.Price = 10;

        item.UsageTimeFormat = timeFormat;
        item.UsageTime = usageTime;
        item.Wattage = wattage;
        item.UpdateItem();

        Assert.Equal(expected, item.Cost);
    }
}

// public class ItemListTest
// {
//     [Fact]
//     public void PassingTest()
//     {
//         Assert.Equal(4, Add(2, 2));
//     }

//     [Fact]
//     public void FailingTest()
//     {
//         Assert.Equal(5, Add(2, 2));
//     }

//     int Add(int x, int y)
//     {
//         return x + y;
//     }
// }
