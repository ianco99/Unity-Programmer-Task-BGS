using System.Collections.Generic;

namespace BGS.Inventory
{
    [System.Serializable]
    public class InventoryData
    {
        public List<InventoryItemData> items = new List<InventoryItemData>();
    }
}