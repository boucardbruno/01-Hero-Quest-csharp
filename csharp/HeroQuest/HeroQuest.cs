namespace CodingDojo;

public class HeroQuest
{
    public string? Name { get; init; }
    
    public int Health { get; set; }
    
    public int Strength { get; set; } 
    
    public int Magic { get; set; }
    
    public int CraftingSkill { get; init; }

    public void FallsDown()
    {
        Console.WriteLine("Player drops off a cliff.");
        if (Strength < 5)
        {
            Health -= 10;
            Console.WriteLine("Player's strength is too small. Health decreases by 10.");
        }
    }
    
    public void ItemApplyEffectBy(QuestItem questItem) {
        Console.WriteLine($"Applying the effect of {questItem.Name} ({questItem.Kind}):");

        if (questItem.Kind == "Health") {
            Health += questItem.Power;
        } else if (questItem.Kind == "Strength") {
            Strength += questItem.Power;
        } else if (questItem.Kind == "Magic") {
            Magic += questItem.Power;
        }
    }

    override 
    public string ToString()
    {
        return
            $"{Name}'s Attributes:\nHealth: {Health}\nStrength: {Strength}\nMagic: {Magic}\nCrafting Skill: {CraftingSkill}\n";
    }
}