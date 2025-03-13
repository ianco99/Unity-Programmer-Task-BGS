using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryModel
    {
        private List<InventorySlot> _slots;

        private InventoryController _inventoryController;

        public void Init(InventoryController controller)
        {
            _inventoryController = controller;

            if (_slots == null)
                _inventoryController.InitializeInventorySlots();
        
            for (int i = 0; i < _slots.Count; i++)
            {
                _slots[i].OnClick += OnClickHandler;
                _slots[i].OnHovering += OnHoveringHandler;
            }
        }

        public void DeInit()
        {
            ClearItems();
        }

        public void AddItem(Item itemToAdd)
        {
            try
            {
                foreach (var slot in _slots)
                {
                    if (slot.IsEmpty())
                        slot.StoreItem(itemToAdd);
                }
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
                foreach (var slot in _slots)
                {
                    if (slot.StoredItem.ID == idToRemove)
                    {
                        slot.OnClick -= OnClickHandler;
                        slot.OnHovering -= OnHoveringHandler;
                        _slots.RemoveAt(index);
                    }

                    index++;
                }
            }
            catch (System.Exception)
            {
                Debug.LogError("Error removing itemToAdd from inventory");
                throw;
            }
        }

        public void SetItems(List<InventorySlot> slots)
        {
            _slots = slots;
        }

        public void ClearItems()
        {
            try
            {
                for (int i = 0; i < _slots.Count; i++)
                {
                    _slots[i].OnClick -= OnClickHandler;
                    _slots[i].OnHovering -= OnHoveringHandler;
                }
            }
            catch (System.Exception)
            {
                Debug.LogError("Error clearing list.");
                throw;
            }
        }

        private void OnClickHandler(Item item)
        {
            _inventoryController.SlotClicked(item);
        }

        private void OnHoveringHandler(bool value, Item item)
        {
            _inventoryController.SlotHovering(value, item);
        }
    }
}