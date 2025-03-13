using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BGS.Inventory
{
    public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        //private ISlottable _slottable;

        [SerializeField] private Image _slotImage;
        [SerializeField] private GameObject _blinkImage;
        [SerializeField] private BaseItemSettings _itemConfig;

        private Item _storedItem;

        public Item StoredItem => _storedItem;

        public Action<bool, Item> OnHovering;
        public Action<Item> OnLeftClick;
        public Action<Item> OnRightClick;

        private void Awake()
        {
            SlotUpdate();
        }

        public void StoreItem(Item item)
        {
            _storedItem = item;
            UpdateSlotContent();
        }

        public void EmptyItem()
        {
            _storedItem = null;
            UpdateSlotContent();
        }

        private void ToggleHover(bool value)
        {
            OnHovering?.Invoke(value, _storedItem);
            _blinkImage.SetActive(value);
        }

        [ContextMenu("Update slot content")]
        private void SlotUpdate()
        {
            if (_itemConfig)
            {
                Item newItem = new Item(_itemConfig);
                _storedItem = newItem;
            }
            else
            {
                _storedItem = null;
            }

            UpdateSlotContent();
        }

        private void UpdateSlotContent()
        {
            if (_storedItem == null)
            {
                _slotImage.gameObject.SetActive(false);
                return;
            }

            _slotImage.gameObject.SetActive(true);
            _slotImage.sprite = _storedItem.ImagePV;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
                OnLeftClick?.Invoke(_storedItem);
            else if (eventData.button == PointerEventData.InputButton.Right)
                OnRightClick?.Invoke(_storedItem);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ToggleHover(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ToggleHover(false);
        }

        public bool IsEmpty() => _storedItem == null;
    }
}