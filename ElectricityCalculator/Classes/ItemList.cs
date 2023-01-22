namespace ElectricityCalculator.Classes;

public enum TotalTimeFormat
{
    Day,
    Month,
    Year
}

public class ItemList
{
    public List<ItemData> Items = new List<ItemData>();
    public double Price = 250; // ÖRE
    public double TotalKilowattHours { get; set; }
    public double TotalCost { get; set; }
    public TotalTimeFormat TimeFormat { get; set; }

    public void RemoveItem(Guid ID)
    {
        var itemToDelete = Items.Find((item) => item.ID == ID);
        Items.Remove(itemToDelete);
    }
}
