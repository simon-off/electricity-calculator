namespace ElectricityCalculator.Classes;

public enum ItemTimeFormat
{
    Minutes,
    Hours
}

public class ItemData
{
    private double _wattage;
    private double _usageTime;

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
        }
    }
    public ItemTimeFormat UsageTimeFormat { get; set; } = ItemTimeFormat.Hours;
    public double KilowattHours { get; private set; }
    public double Cost { get; private set; }

    public void UpdateOutput(double price)
    {
        Wattage = Wattage;
        UsageTime = UsageTime;

        if (UsageTimeFormat == ItemTimeFormat.Minutes)
        {
            KilowattHours = (_wattage / 1000) * (_usageTime / 60);
        }
        else
        {
            KilowattHours = (_wattage / 1000) * _usageTime;
        }

        Cost = KilowattHours * price;
    }
}
