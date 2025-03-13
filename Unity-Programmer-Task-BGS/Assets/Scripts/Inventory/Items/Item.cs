using UnityEngine;

namespace BGS.Inventory
{
    public class Item
    {
        public BaseItemSettings Config { get; private set; }

        public Item(BaseItemSettings config)
        {
            Config = config;
        }
    }
}
