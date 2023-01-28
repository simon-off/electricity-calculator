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
        ItemList list = new() { Price = 10 };
        ItemData item =
            new(list)
            {
                UsageTimeFormat = timeFormat,
                UsageTime = usageTime,
                Wattage = wattage
            };

        item.UpdateItem();

        Assert.Equal(expected, item.Cost);
    }
}

public class ItemListTest
{
    [Theory]
    [InlineData(1, TotalTimeFormat.Day, 10)]
    [InlineData(-1, TotalTimeFormat.Day, 0)]
    [InlineData(500, TotalTimeFormat.Day, 5000)]
    public void UpdateListTest(double price, TotalTimeFormat timeFormat, double expected)
    {
        ItemList list = new() { Price = price, TimeFormat = timeFormat };
        list.Items.Add(new ItemData(list) { Wattage = 100, UsageTime = 24 });
        list.Items.Add(new ItemData(list) { Wattage = 200, UsageTime = 8 });
        list.Items.Add(new ItemData(list) { Wattage = 1000, UsageTime = 6 });

        list.UpdateList();

        Assert.Equal(expected, list.TotalCost);
    }
}
