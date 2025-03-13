namespace BGS.Inventory
{
    [System.Serializable]
    public class InventoryItemData
    {
        public string itemType;
        public int slotID;

        public InventoryItemData(string type, int slotId)
        {
            itemType = type;
            slotID = slotId;
        }
    }
}