namespace CodingDojo.Test;

using CodingDojo;

public class HeroQuestTest
{
    private readonly QuestData _questData = new()
    {
        Player = new Player { Name = "Conan" , Health = 100, Strength = 20, Magic = 10, CraftingSkill = 10},
        Item = new Item { Name = "Amulet of Strength", Kind = "Strength", Power = 10}
    };

    [Fact]
    void PlayerToString()
    {
        var result = HeroQuest.PlayerToString(_questData.Player);

        var expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                       "10\nCrafting " +
                       "Skill: 10\n";

        Assert.Equal(expected, result);
    }

    [Fact]
    void PlayerFallsDown()
    {
        _questData.Player.Strength = 3;
        HeroQuest.PlayerFallsDown(_questData.Player);
        Assert.Equal(90, _questData.Player.Health);
    }

    [Fact]
    void PlayerFallsDownNoDamage()
    {
        HeroQuest.PlayerFallsDown(_questData.Player);
        Assert.Equal(100, _questData.Player.Health);
    }

    [Fact]
    void ItemToString()
    {
        var result = HeroQuest.ItemToString(_questData.Item);
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    void ItemReduceByUsage()
    {
        HeroQuest.ItemReduceByUsage(_questData.Item);
        Assert.Equal(5, _questData.Item.Power);
    }

    [Fact]
    void ItemReduceByUsageToJunk()
    {
        _questData.Item.Power = 1;
        HeroQuest.ItemReduceByUsage(_questData.Item);
        Assert.Equal(0, _questData.Item.Power);
        Assert.Equal("Junk", _questData.Item.Kind);
    }

    [Fact]
    void ItemApplyEffectToPlayer()
    {
        HeroQuest.ItemApplyEffectToPlayer(_questData.Player, _questData.Item);
        Assert.Equal(30, _questData.Player.Strength);
    }

    [Fact]
    void ItemApplyEffectToPlayerJunk()
    {
        _questData.Item.Kind = "Junk";
        HeroQuest.ItemApplyEffectToPlayer(_questData.Player, _questData.Item);
        Assert.Equal(20, _questData.Player.Strength);
    }

    [Fact]
    void ItemRepair()
    {
        HeroQuest.ItemRepair(_questData.Player, _questData.Item);
        Assert.Equal(26, _questData.Item.Power);
    }
}