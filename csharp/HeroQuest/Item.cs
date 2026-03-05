namespace CodingDojo;

public class Item
{
    public string? Name { get; set; }
    
    public string? Kind { get; set; }
    
    public int  Power { get; set; }

    public void ReduceByUsage()
    {
        Console.WriteLine($"Using the item with kind '{Kind}' and power {Power}");
        Power /= 2;
        if (Power == 0)
        {
            Kind = "Junk";
        }
    }
    
    public void ItemRepairBy(Player player) {
        Console.WriteLine("Using the repair skill to fix the item:");

        var repairAmount = -5 + ((player.CraftingSkill) * 2) + 1;

        Power =  (Power + repairAmount);

        Console.WriteLine($"Repaired the item by {repairAmount} points. Item's Durability: {Power}");
    }
    public override string ToString()
    {
        return $"Item: {Name}\nKind: {Kind}\nPower: {Power}\n";
    }
}