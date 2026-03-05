namespace CodingDojo;

public class Player
{
    public string? Name { get; set; }
    
    public int Health { get; set; }
    
    public int Strength { get; set; } 
    
    public int Magic { get; set; }
    
    public int CraftingSkill { get; set; }

    public void FallsDown()
    {
        Console.WriteLine("Player drops off a cliff.");
        if (Strength < 5)
        {
            Health -= 10;
            Console.WriteLine("Player's strength is too small. Health decreases by 10.");
        }
    }
    
    public void ItemApplyEffectBy(Item item) {
        Console.WriteLine($"Applying the effect of {item.Name} ({item.Kind}):");

        if (item.Kind == "Health") {
            Health += item.Power;
        } else if (item.Kind == "Strength") {
            Strength += item.Power;
        } else if (item.Kind == "Magic") {
            Magic += item.Power;
        }
    }

    override 
    public string ToString()
    {
        return
            $"{Name}'s Attributes:\nHealth: {Health}\nStrength: {Strength}\nMagic: {Magic}\nCrafting Skill: {CraftingSkill}\n";
    }
}