namespace CodingDojo.StrategyEffect;

public class MagicEffect(HeroQuest heroQuest) : IProvideEffect
{
    public void ApplyEffect(QuestItem questItem)
    {
        heroQuest.Magic += questItem.Power;
    }
}