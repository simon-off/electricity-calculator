namespace ElectricityCalculator.Classes;

public enum TotalTimeFormat
{
    Day = 1,
    Month = 30,
    Year = 365
}

public class ItemList
{
    public event EventHandler? Refresh;

    private double _price = 0;
    private TotalTimeFormat _timeFormat = TotalTimeFormat.Day;

    public List<ItemData> Items = new List<ItemData>();
    public double Price
    {
        get { return _price; }
        set
        {
            _price = Math.Clamp(value, 0, double.MaxValue);
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

        TotalKilowattHours = (
            Items.Aggregate(0d, (acc, item) => acc + item.KilowattHours) * (double)TimeFormat
        );
        TotalCost = Items.Aggregate(0d, (acc, item) => acc + item.Cost) * (double)TimeFormat;

        Refresh?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Guid ID)
    {
        var itemToDelete = Items.Find((item) => item.ID == ID);
        if (itemToDelete != null)
        {
            Items.Remove(itemToDelete);
        }
    }
}
