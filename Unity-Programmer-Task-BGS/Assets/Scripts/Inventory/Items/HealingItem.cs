namespace BGS.Inventory
{
    public class HealingItem : Item
    {
        public HealingItem(HealingItemSettings config) : base(config)
        {
            Config = config;
        }
    }
}
