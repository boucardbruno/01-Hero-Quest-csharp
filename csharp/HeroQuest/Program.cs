using CodingDojo;

QuestAdventure questAdventure = new ()
{
    HeroQuest = new HeroQuest { Name = "Conan" , Health = 100, Strength = 20, Magic = 10, CraftingSkill = 10},
    QuestItem = new QuestItem { Name = "Amulet of Strength", Kind = "Strength", Power = 10}
};

var result = questAdventure.HeroQuest.ToString();
Console.WriteLine(result);

result = questAdventure.QuestItem.ToString();
Console.WriteLine(result);

questAdventure.HeroQuest.ItemApplyEffectBy(questAdventure.QuestItem);
questAdventure.QuestItem.ReduceByUsage();

result = questAdventure.HeroQuest.ToString();;
Console.WriteLine(result);

result = questAdventure.QuestItem.ToString();
Console.WriteLine(result);

Console.WriteLine("Player tries to repair item...");
questAdventure.QuestItem.ItemRepairBy(questAdventure.HeroQuest);

result = questAdventure.QuestItem.ToString();
Console.WriteLine(result);