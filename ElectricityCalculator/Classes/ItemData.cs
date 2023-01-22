namespace ElectricityCalculator.Classes;

public enum ItemTimeFormat
{
    Minutes,
    Hours
}

public class ItemData
{
    public Guid ID { get; } = Guid.NewGuid();

    public string Title { get; set; } = "";
    public double Wattage { get; set; }
    public double UsageTime { get; set; }
    public ItemTimeFormat UsageTimeFormat { get; set; } = ItemTimeFormat.Hours;
}
