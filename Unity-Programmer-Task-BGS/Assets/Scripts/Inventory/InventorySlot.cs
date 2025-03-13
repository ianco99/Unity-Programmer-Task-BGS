using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BGS.Inventory
{
    public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private ISlottable _slottable;

        [SerializeField] private Image _slotImage;
        [SerializeField] private GameObject _blinkImage;
        [SerializeField] private BaseItemSettings _itemConfig;

        private Item _storedItem;

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
            _blinkImage.SetActive(value);
        }

        [ContextMenu("Update slot content")]
        private void EditorSlotUpdate()
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
            if(_storedItem == null)
            {
                _slotImage.gameObject.SetActive(false);
                return;
            }

            _slotImage.gameObject.SetActive(true);
            _slotImage.overrideSprite = _storedItem.ImagePV;
        }
    }
}