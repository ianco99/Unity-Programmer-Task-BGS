using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BGS.Inventory
{
    public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private ISlottable _slottable;

        [SerializeField] private Image _slotImage;
        [SerializeField] private GameObject _blinkImage;
        [SerializeField] private BaseItemSettings _itemConfig;

        private Item _storedItem;

        public Item StoredItem => _storedItem;

        public Action<bool, Item> OnHovering;
        public Action<Item> OnClick;

        private void Awake()
        {
            SlotUpdate();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ToggleHover(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ToggleHover(false);
        }

        public void StoreItem(Item item)
        {
            _storedItem = item;
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
            OnClick?.Invoke(_storedItem);
        }

        public bool IsEmpty() => _storedItem == null;
    }
}