namespace ElectricityCalculator.Classes;

public enum TotalTimeFormat
{
    Day = 1,
    Month = 30,
    Year = 365
}

public class ItemList
{
    public event EventHandler Refresh;

    private double _price = 250;
    private TotalTimeFormat _timeFormat = TotalTimeFormat.Day;

    public List<ItemData> Items = new List<ItemData>();
    public double Price
    {
        get { return _price; }
        set
        {
            _price = value;
            UpdateList();
        }
    }
    public double TotalKilowattHours { get; set; }
    public double TotalCost { get; set; }
    public TotalTimeFormat TimeFormat
    {
        get { return _timeFormat; }
        set
        {
            _timeFormat = value;
            UpdateList();
        }
    }

    public void UpdateList()
    {
        foreach (ItemData item in Items)
        {
            item.UpdateItem();
        }

        TotalKilowattHours = Items.Aggregate(0d, (acc, item) => acc + item.KilowattHours);
        TotalCost = Items.Aggregate(0d, (acc, item) => acc + item.Cost) * (double)TimeFormat;

        Refresh?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Guid ID)
    {
        var itemToDelete = Items.Find((item) => item.ID == ID);
        Items.Remove(itemToDelete);
    }
}
