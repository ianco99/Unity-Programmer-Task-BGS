using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private GameObject _inventorySlotPrefab;
        [SerializeField] private Transform _slotsParent;
        [SerializeField] private List<InventorySlot> _slots;

        [SerializeField] private int _inventorySize;

        [SerializeField] private InventoryView _inventoryView;

        private void Awake()
        {
            Init();
        }

        private void OnDestroy()
        {
            ClearItems();
        }

        private void Init()
        {

            if (_slots == null)
                InitializeInventorySlots();

            for (int i = 0; i < _slots.Count; i++)
            {
                _slots[i].OnClick += OnClickHandler;
                _slots[i].OnHovering += OnHoveringHandler;
            }
        }

        [ContextMenu("Spawn slot grid")]    //Button useful for editor visual adjustments
        private void InitializeInventorySlots()
        {
            _slots = new List<InventorySlot>();

            for (int i = 0; i < _inventorySize; i++)
            {
                GameObject slot = Instantiate(_inventorySlotPrefab, _slotsParent);
                _slots.Add(slot.GetComponent<InventorySlot>());
            }
        }

        private void OnClickHandler(Item item)
        {
            if (item == null)
                _inventoryView.ClearDetailsPanel();
            else
                _inventoryView.UpdateDetailsPanel(item.ImageHD, item.Description, item.Quote);
        }

        private void OnHoveringHandler(bool value, Item item)
        {

        }

        public void AddItem(Item itemToAdd)
        {
            try
            {
                foreach (var item in _slots)
                {
                    if (item.IsEmpty())
                        item.StoreItem(itemToAdd);
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
                foreach (var item in _slots)
                {
                    if (item.StoredItem.ID == idToRemove)
                    {
                        item.OnClick -= OnClickHandler;
                        item.OnHovering -= OnHoveringHandler;
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
    }
}