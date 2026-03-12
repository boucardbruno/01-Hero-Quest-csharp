using System.Collections.Generic;

namespace CodingDojo.StrategyEffect;

public class StrategyFactoryEffect(HeroQuest heroQuest)
{
    private readonly Dictionary<KindOfItem, IProvideEffect> _strategies = new()
    {
        { KindOfItem.Health, new HealthEffect(heroQuest) },
        { KindOfItem.Strength, new StrengthEffect(heroQuest) },
        { KindOfItem.Magic, new MagicEffect(heroQuest) },
        { KindOfItem.Junk, new JunkEffect(heroQuest) }
    };

    public IProvideEffect GetStrategy(KindOfItem kind)
    {
        return _strategies[kind];
    }
}