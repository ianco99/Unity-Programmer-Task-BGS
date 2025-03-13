using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private GameObject _inventorySlotPrefab;
        [SerializeField] private int _inventorySlotCount;

        private List<Item> _items;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            _items = new List<Item>();
        }


        public void AddItem(Item itemToAdd)
        {
            try
            {
                _items.Add(itemToAdd);
            }
            catch (System.Exception)
            {
                Debug.LogError("Error adding itemToAdd to inventory");
                throw;
            }
        }

        public void RemoveItem(int idToRemove)
        {
            try
            {
                int index = 0;
                foreach (var item in _items)
                {
                    if (item.ID == idToRemove)
                        _items.RemoveAt(index);

                    index++;
                }
            }
            catch (System.Exception)
            {
                Debug.LogError("Error removing itemToAdd from inventory");
                throw;
            }
        }

        public void ClearItems()
        {
            try
            {
                _items.Clear();
            }
            catch (System.Exception)
            {
                Debug.LogError("Error clearing list.");
                throw;
            }
        }
    }
}