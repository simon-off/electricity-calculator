namespace ElectricityCalculator.Data;

public enum ItemTimeFormat
{
    Minutes,
    Hours
}

public class ItemData {
    // Här behöver vi alla properties som watt, timmar osv.
    public string Title {get; set;} = "";
    public double Watt {get; set;} = 0;
    public double UsageTime{get;set;} = 0;
    public ItemTimeFormat UsageTimeFormat {get; set;} = ItemTimeFormat.Hours;
}