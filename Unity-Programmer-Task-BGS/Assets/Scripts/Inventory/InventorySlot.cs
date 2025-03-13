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
        }

        private void ToggleHover(bool value)
        {
            _blinkImage.SetActive(value);
        }

    }
}