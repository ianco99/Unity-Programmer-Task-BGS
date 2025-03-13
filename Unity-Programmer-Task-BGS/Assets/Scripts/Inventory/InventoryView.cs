using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Image _detailsImage;
        [SerializeField] private TMP_Text _detailsText;
        [SerializeField] private TMP_Text _quoteText;

        public void UpdateDetailsPanel(Sprite sprite, string detailsText, string quoteText)
        {
            ToggleDetails(true);


            _detailsImage.sprite = sprite;

            _detailsText.text = detailsText;
            _quoteText.text = quoteText;
        }

        public void ClearDetailsPanel()
        {
            ToggleDetails(false);
        }
        
        private void ToggleDetails(bool value)
        {
            _detailsImage.gameObject.SetActive(value);
            _detailsText.gameObject.SetActive(value);
            _quoteText.gameObject.SetActive(value);
        }
    }
}