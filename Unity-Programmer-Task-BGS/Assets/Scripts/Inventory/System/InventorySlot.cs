using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BGS.Inventory
{
    public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _slotImage;
        [SerializeField] private GameObject _blinkImage;
        [SerializeField] private BaseItemSettings _itemConfig;

        private Item _storedItem;

        private bool isHolding = false;
        private bool isDraggingItem = false;
        private float holdTime = 0.3f;
        private float holdTimer = 0f;

        public Item StoredItem => _storedItem;

        public Action<bool, InventorySlot> OnHovering;
        public Action<Item> OnLeftClick;
        public Action<Item> OnRightClick;
        public Action<bool, Item, InventorySlot> OnLeftHold;

        private void Awake()
        {
            SlotUpdate();
        }

        private void Update()
        {
            if (isHolding)
            {
                holdTimer += Time.deltaTime;
                if (holdTimer >= holdTime)
                {
                    OnHoldComplete();
                    isHolding = false;
                }
            }
        }

        public void StoreItem(Item item)
        {
            _storedItem = item;

            if (item != null)
                _itemConfig = item.Config;
            
            UpdateSlotVisuals();
        }

        public void EmptyItem()
        {
            _storedItem = null;
            UpdateSlotVisuals();
        }

        private void ToggleHover(bool value)
        {
            OnHovering?.Invoke(value, this);
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

            UpdateSlotVisuals();
        }

        private void UpdateSlotVisuals()
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

            isHolding = false;
            holdTimer = 0f;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isHolding = true;
            holdTimer = 0f;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isHolding = false;
            holdTimer = 0f;

            if (isDraggingItem && _storedItem != null)
            {
                OnLeftHold?.Invoke(false, _storedItem, this);
            }
        }

        private void OnHoldComplete()
        {
            if (_storedItem != null)
            {
                OnLeftHold?.Invoke(true, _storedItem, this);
            }

            isDraggingItem = true;
            Debug.Log("Hold Completed!");
        }

        public bool IsEmpty() => _storedItem == null;
    }
}