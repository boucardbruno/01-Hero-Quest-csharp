namespace CodingDojo.StrategyEffect;

public class HealthEffect(HeroQuest heroQuest) : IProvideEffect
{
    public void ApplyEffect(QuestItem questItem)
    {
        heroQuest.Health += questItem.Power;
    }
}