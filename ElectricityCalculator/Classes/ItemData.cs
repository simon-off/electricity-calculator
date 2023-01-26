namespace ElectricityCalculator.Classes;

public enum ItemTimeFormat
{
    Minutes,
    Hours
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
            if (value < 0)
            {
                _wattage = 0;
            }
            else
            {
                _wattage = value;
            }

            _list.UpdateList();
        }
    }
    public double UsageTime
    {
        get { return _usageTime; }
        set
        {
            if (value < 0)
            {
                _usageTime = 0;
            }
            else if (UsageTimeFormat == ItemTimeFormat.Hours && value > 24)
            {
                _usageTime = 24;
            }
            else if (UsageTimeFormat == ItemTimeFormat.Minutes && value > 1440)
            {
                _usageTime = 1440;
            }
            else
            {
                _usageTime = value;
            }

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

    // Gets called from ItemList
    public void UpdateItem()
    {
        if (UsageTimeFormat == ItemTimeFormat.Minutes)
        {
            KilowattHours = (_wattage / 1000) * (_usageTime / 60);
        }
        else
        {
            KilowattHours = (_wattage / 1000) * _usageTime;
        }

        Cost = KilowattHours * _list.Price;
    }
}
