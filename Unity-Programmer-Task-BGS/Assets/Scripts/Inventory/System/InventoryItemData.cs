namespace BGS.Inventory
{
    [System.Serializable]
    public class InventoryItemData
    {
        public string itemName;
        public int slotID;

        public InventoryItemData(string type, int slotId)
        {
            itemName = type;
            slotID = slotId;
        }
    }
}