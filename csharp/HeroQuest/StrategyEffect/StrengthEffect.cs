namespace CodingDojo.StrategyEffect;

public class StrengthEffect(HeroQuest heroQuest) : IProvideEffect
{
    public void ApplyEffect(QuestItem questItem)
    {
        heroQuest.Strength += questItem.Power;
    }
}