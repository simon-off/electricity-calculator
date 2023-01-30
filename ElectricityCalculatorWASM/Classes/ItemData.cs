namespace ElectricityCalculatorWASM.Classes;

public enum ItemTimeFormat
{
    Minutes = 60,
    Hours = 1
}

public class ItemData
{
    public ItemData(ItemList list)
    {
        _list = list;
    }

    private ItemList _list;
    private double _wattage;
    private double _usageTime;
    private ItemTimeFormat _usageTimeFormat = ItemTimeFormat.Hours;

    public Guid ID { get; } = Guid.NewGuid();
    public string Title { get; set; } = "";
    public double Wattage
    {
        get { return _wattage; }
        set
        {
            _wattage = Math.Clamp(value, 0, double.MaxValue);
            _list.UpdateList();
        }
    }
    public double UsageTime
    {
        get { return _usageTime * (double)UsageTimeFormat; }
        set
        {
            _usageTime = Math.Clamp(value / (double)UsageTimeFormat, 0, 24);
            _list.UpdateList();
        }
    }
    public ItemTimeFormat UsageTimeFormat
    {
        get { return _usageTimeFormat; }
        set
        {
            _usageTimeFormat = value;
            _list.UpdateList();
        }
    }
    public double KilowattHours { get; private set; }
    public double Cost { get; private set; }

    // Gets called from ItemList. Calculates the cost and kwh
    public void UpdateItem()
    {
        KilowattHours = (_wattage / 1000) * (_usageTime);
        Cost = KilowattHours * _list.Price;
    }
}
