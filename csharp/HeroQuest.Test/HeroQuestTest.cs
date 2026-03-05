namespace CodingDojo.Test;

using CodingDojo;

public class HeroQuestTest
{
    private readonly QuestAdventure _questAdventure = new()
    {
        HeroQuest = new HeroQuest { Name = "Conan" , Health = 100, Strength = 20, Magic = 10, CraftingSkill = 10},
        QuestItem = new QuestItem { Name = "Amulet of Strength", Kind = "Strength", Power = 10}
    };

    [Fact]
    void PlayerToString()
    {
        var result = _questAdventure.HeroQuest.ToString();

        var expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                       "10\nCrafting " +
                       "Skill: 10\n";

        Assert.Equal(expected, result);
    }

    [Fact]
    void PlayerFallsDown()
    {
        _questAdventure.HeroQuest.Strength = 3;
        _questAdventure.HeroQuest.FallsDown();
        Assert.Equal(90, _questAdventure.HeroQuest.Health);
    }

    [Fact]
    void PlayerFallsDownNoDamage()
    {
        _questAdventure.HeroQuest.FallsDown();
        Assert.Equal(100, _questAdventure.HeroQuest.Health);
    }

    [Fact]
    void ItemToString()
    {
        var result = _questAdventure.QuestItem.ToString();
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    void ItemReduceByUsage()
    {
        _questAdventure.QuestItem.ReduceByUsage();
        Assert.Equal(5, _questAdventure.QuestItem.Power);
    }

    [Fact]
    void ItemReduceByUsageToJunk()
    {
        _questAdventure.QuestItem.Power = 1;
        _questAdventure.QuestItem.ReduceByUsage();
        Assert.Equal(0, _questAdventure.QuestItem.Power);
        Assert.Equal("Junk", _questAdventure.QuestItem.Kind);
    }

    [Fact]
    void ItemApplyEffectToPlayer()
    {
        _questAdventure.HeroQuest.ItemApplyEffectBy(_questAdventure.QuestItem);
        Assert.Equal(30, _questAdventure.HeroQuest.Strength);
    }

    [Fact]
    void ItemApplyEffectToPlayerJunk()
    {
        _questAdventure.QuestItem.Kind = "Junk";
        _questAdventure.HeroQuest.ItemApplyEffectBy(_questAdventure.QuestItem);
        Assert.Equal(20, _questAdventure.HeroQuest.Strength);
    }

    [Fact]
    void ItemRepair()
    {
         _questAdventure.QuestItem.ItemRepairBy(_questAdventure.HeroQuest);
        Assert.Equal(26, _questAdventure.QuestItem.Power);
    }
}