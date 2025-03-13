namespace BGS.Inventory
{
    public class HealingItem : Item
    {
        public int HealAmount;
        public HealingItem(HealingItemSettings config) : base(config)
        {
            HealAmount = config.HealAmount;
        }
    }
}
