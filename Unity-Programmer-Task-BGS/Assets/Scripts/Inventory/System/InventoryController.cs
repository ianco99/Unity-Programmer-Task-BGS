using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        private InventoryModel _inventoryModel = new InventoryModel();

        [SerializeField] private GameObject _inventorySlotPrefab;
        [SerializeField] private BaseItemSettings _testSettings;
        [SerializeField] private Transform _slotsParent;
        [SerializeField] private TrashSlot[] _trashSlots;

        [SerializeField] private int _inventorySize;

        private InventorySlot _hoveredSlot;
        private bool _hoveringTrash;

        private void Awake()
        {
            Init();
        }

        private void OnDestroy()
        {
            _inventoryModel.DeInit();
        }

        private void Init()
        {
            _inventoryModel.Init(this);

            for (int i = 0; i < _trashSlots.Length; i++)
            {
                _trashSlots[i].OnHovering += TrashHovering;
            }
        }

        [ContextMenu("Spawn slot grid")]    //Button useful for editor visual adjustments
        public void InitializeInventorySlots()
        {

            var _slots = new List<InventorySlot>();

            _slots.AddRange(RetrieveEditorInventorySlots());

            for (int i = _slots.Count; i < _inventorySize; i++)
            {
                GameObject slot = Instantiate(_inventorySlotPrefab, _slotsParent);
                _slots.Add(slot.GetComponent<InventorySlot>());
            }

            _inventoryModel.SetItems(_slots);
        }

        [ContextMenu("Delete slot grid")]
        private void DeInitializeInventorySlots()
        {
            var childs = _slotsParent.GetComponentsInChildren<InventorySlot>();

            foreach (InventorySlot child in childs)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        public List<InventorySlot> RetrieveEditorInventorySlots()
        {
            List<InventorySlot> slots = new List<InventorySlot>();

            var childs = _slotsParent.GetComponentsInChildren<InventorySlot>();

            slots.AddRange(childs);

            return slots;
        }

        public void RemoveAllItems()
        {
            _inventoryModel.RemoveAllItems();
        }

        public List<InventorySlot> GetSlots() => _inventoryModel.Slots;

        public void SlotLeftClicked(Item item)
        {
            if (item == null)
                _inventoryView.ClearDetailsPanel();
            else
                _inventoryView.UpdateDetailsPanel(item.Config.ImageHD, item.Config.Description, item.Config.Quote);
        }

        public void SlotLeftHolded(bool value, Item item, InventorySlot slot)
        {
            if (value)
            {
                _inventoryView.SetDragNDropImage(item?.Config.ImagePV);

                for (int i = 0; i < _trashSlots.Length; i++)
                {
                    _trashSlots[i].gameObject.SetActive(true);
                }
            }
            else
            {
                _inventoryView.SetDragNDropImage(null);

                if(_hoveredSlot != null)
                {
                    _inventoryModel.SwapItems(slot, _hoveredSlot);
                }
                else if (_hoveringTrash)
                {
                    _inventoryModel.RemoveItem(item);
                }

                for (int i = 0; i < _trashSlots.Length; i++)
                {
                    _trashSlots[i].gameObject.SetActive(false);
                }
            }
        }

        public void SlotRightClicked(Item item)
        {

        }

        public void SlotHovering(bool value, InventorySlot slot)
        {
            if (value)
                _hoveredSlot = slot;
            else
                _hoveredSlot = null;
        }

        private void TrashHovering(bool value)
        {
            _hoveringTrash = value;
        }

        [ContextMenu("Add test item")]
        private void AddTestItem()
        {
            Item item = new Item(_testSettings);
            _inventoryModel.AddItem(item);
        }

        public void AddItem(Item item)
        {
            _inventoryModel.AddItem(item);
        }

        public void AddItemAt(int index, Item item)
        {
            _inventoryModel.AddItemAt(index, item);
        }
    }
}