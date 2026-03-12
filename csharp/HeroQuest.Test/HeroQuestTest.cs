using NFluent;
using NUnit.Framework;

namespace CodingDojo.Test;

[TestFixture]
public class HeroQuestTest
{
    private QuestAdventure _questAdventure = null!;
    [SetUp]
    public void Init()
    {
        _questAdventure = new()
        {
            HeroQuest = new HeroQuest { Name = "Conan", Health = 100, Strength = 20, Magic = 10, CraftingSkill = 10 },
            QuestItem = new QuestItem { Name = "Amulet of Strength", Kind = KindOfItem.Strength, Power = 10 }
        };
    }
    
    [Test]
    public void PlayerToString()
    {
        var result = _questAdventure.HeroQuest.ToString();

        Check.That(result)
            .IsEqualTo("Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                       "10\nCrafting " +
                       "Skill: 10\n");
    }

    [Test]
    public void PlayerFallsDown()
    {
        _questAdventure.HeroQuest.Strength = 3;
        _questAdventure.HeroQuest.FallsDown();
        Check.That(_questAdventure.HeroQuest.Health).IsEqualTo(90);
    }

    [Test]
    public void PlayerFallsDownNoDamage()
    {
        _questAdventure.HeroQuest.FallsDown();
        Check.That(_questAdventure.HeroQuest.Health).IsEqualTo(100);
    }

    [Test]
    public void ItemToString()
    {
        var result = _questAdventure.QuestItem.ToString();
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        Check.That(result).IsEqualTo(expected);
    }

    [Test]
    public void ItemReduceByUsage()
    {
        _questAdventure.QuestItem.ReduceByUsage();
        Check.That(_questAdventure.QuestItem.Power).IsEqualTo(5);
    }

    [Test]
    public void ItemReduceByUsageToJunk()
    {
        _questAdventure.QuestItem.Power = 1;
        _questAdventure.QuestItem.ReduceByUsage();
        Check.That(_questAdventure.QuestItem.Power).IsEqualTo(0);
        Check.That(_questAdventure.QuestItem.Kind).IsEqualTo(KindOfItem.Junk);
    }

    [Test]
    public void ItemApplyEffectToPlayer()
    {
        _questAdventure.HeroQuest.ItemApplyEffectBy(_questAdventure.QuestItem);
        Check.That(_questAdventure.HeroQuest.Strength).IsEqualTo(30);
    }

    [Test]
    public void ItemApplyEffectToPlayerJunk()
    {
        _questAdventure.QuestItem.Kind = KindOfItem.Junk;
        _questAdventure.HeroQuest.ItemApplyEffectBy(_questAdventure.QuestItem);
        Check.That(_questAdventure.HeroQuest.Strength).IsEqualTo(20);
    }

    [Test]
    public void ItemRepair()
    {
        _questAdventure.QuestItem.ItemRepairBy(_questAdventure.HeroQuest);
        Check.That(_questAdventure.QuestItem.Power).IsEqualTo(26);
    }
}