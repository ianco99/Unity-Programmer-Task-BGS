using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryModel
    {
        private List<InventorySlot> _slots;

        private InventoryController _inventoryController;

        public List<InventorySlot> Slots => _slots;

        public void Init(InventoryController controller)
        {
            _inventoryController = controller;

            if (_slots == null)
                _inventoryController.InitializeInventorySlots();

            for (int i = 0; i < _slots.Count; i++)
            {
                _slots[i].OnLeftClick += OnLeftClickHandler;
                _slots[i].OnLeftHold += OnLeftHoldHandler;
                _slots[i].OnRightClick += OnRightClickHandler;
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
                    {
                        slot.StoreItem(itemToAdd);
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                Debug.LogError("Error adding itemToAdd to inventory");
                throw;
            }
        }

        public void RemoveItem(Item item)
        {
            try
            {
                foreach (var slot in _slots)
                {
                    if (slot.StoredItem == null)
                        continue;

                    if (slot.StoredItem == item)
                    {
                        slot.EmptyItem();
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                Debug.LogError("Error removing item from inventory");
                throw;
            }
        }

        public void SwapItems(InventorySlot a, InventorySlot b)
        {
            try
            {
                var aux = a.StoredItem;
                a.StoreItem(b.StoredItem);
                b.StoreItem(aux);
            }
            catch (System.Exception)
            {
                Debug.LogError("Error swapping items in inventory");
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
                    _slots[i].OnLeftClick -= OnLeftClickHandler;
                    _slots[i].OnLeftHold -= OnLeftHoldHandler;
                    _slots[i].OnRightClick -= OnLeftClickHandler;
                    _slots[i].OnHovering -= OnHoveringHandler;
                }
            }
            catch (System.Exception)
            {
                Debug.LogError("Error clearing list.");
                throw;
            }
        }

        private void OnLeftClickHandler(Item item)
        {
            _inventoryController.SlotLeftClicked(item);
        }

        private void OnLeftHoldHandler(bool value, Item item, InventorySlot slot)
        {
            _inventoryController.SlotLeftHolded(value, item, slot);
        }

        private void OnRightClickHandler(Item item)
        {
            _inventoryController.SlotRightClicked(item);
        }

        private void OnHoveringHandler(bool value, InventorySlot slot)
        {
            _inventoryController.SlotHovering(value, slot);
        }
    }
}