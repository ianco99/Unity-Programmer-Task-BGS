using BGS.Inventory;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryLoader : MonoBehaviour
    {
        [SerializeField] private InventoryController _inventoryController;
        public static InventoryLoader Instance;
        private string _savePath;

        public List<InventoryItemData> inventory = new List<InventoryItemData>();

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _savePath = Path.Combine(Application.persistentDataPath, "inventory.json");
        }

        public void SaveInventory()
        {
            InventoryData data = new InventoryData();

            CopyInventoryData(_inventoryController.GetSlots());

            data.items = inventory; // Copy the inventory list

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(_savePath, json);
            Debug.Log($"Inventory saved to: {_savePath}");
        }

        private void CopyInventoryData(List<InventorySlot> slotData)
        {
            inventory.Clear();

            Debug.Log($"inventory slots data: {slotData.Count}");
            for (int i = 0; i < slotData.Count; i++)
            {
                if (slotData[i].StoredItem != null)
                {
                    InventoryItemData data = new InventoryItemData(slotData[i].StoredItem.Type, i);
                    inventory.Add(data);
                }
            }
        }

        public void LoadInventory()
        {
            if (File.Exists(_savePath))
            {
                string json = File.ReadAllText(_savePath);
                InventoryData data = JsonUtility.FromJson<InventoryData>(json);
                inventory = data.items; // Restore inventory
                Debug.Log("Inventory loaded successfully!");
            }
            else
            {
                Debug.LogWarning("No inventory file found, starting fresh.");
            }
        }
    }
}