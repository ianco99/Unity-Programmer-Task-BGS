using UnityEngine;

namespace BGS.Inventory
{
    public class Item
    {
        public BaseItemSettings Config;

        public Item(BaseItemSettings config)
        {
            Config = config;
        }
    }
}
