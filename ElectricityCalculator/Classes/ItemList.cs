namespace ElectricityCalculator.Classes;

public class ItemList
{
    public List<ItemData> Items = new List<ItemData>();

    public void RemoveItem(Guid ID)
    {
        var itemToDelete = Items.Find((item) => item.ID == ID);
        Items.Remove(itemToDelete);
    }
}
