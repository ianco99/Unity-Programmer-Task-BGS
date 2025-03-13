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
        [SerializeField] private Transform _slotsParent;

        [SerializeField] private int _inventorySize;

        private InventorySlot _editorInstantiatedSlots;

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

        public void SlotClicked(Item item)
        {
            if (item == null)
                _inventoryView.ClearDetailsPanel();
            else
                _inventoryView.UpdateDetailsPanel(item.ImageHD, item.Description, item.Quote);
        }

        public void SlotHovering(bool value, Item item)
        {

        }
    }
}