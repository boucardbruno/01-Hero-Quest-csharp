namespace CodingDojo;

public static class HeroQuest
{
    public static string PlayerToString(Player player)
    {
        return player.ToString();
    }

    public static void PlayerFallsDown(Player player)
    {
       player.FallsDown();
    }

    public static string ItemToString(Item item)
    {
        return item.ToString();
    }

    public static void ItemReduceByUsage(Item item)
    {
        item.ReduceByUsage();
    }
    
    public static void ItemApplyEffectToPlayer(Player player, Item item) {
        player.ItemApplyEffectBy(item);
    }
    
    public static void ItemRepair(Player player, Item item) {
        item.ItemRepairBy(player);
    }
}