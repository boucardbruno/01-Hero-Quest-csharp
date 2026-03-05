using CodingDojo;

QuestData questData = new ()
{
    Player = new Player { Name = "Conan" , Health = 100, Strength = 20, Magic = 10, CraftingSkill = 10},
    Item = new Item { Name = "Amulet of Strength", Kind = "Strength", Power = 10}
};

var result = HeroQuest.PlayerToString(questData.Player);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.Item);
Console.WriteLine(result);

HeroQuest.ItemApplyEffectToPlayer(questData.Player, questData.Item);
HeroQuest.ItemReduceByUsage(questData.Item);

result = HeroQuest.PlayerToString(questData.Player);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.Item);
Console.WriteLine(result);

Console.WriteLine("Player tries to repair item...");
HeroQuest.ItemRepair(questData.Player, questData.Item);

result = HeroQuest.ItemToString(questData.Item);
Console.WriteLine(result);