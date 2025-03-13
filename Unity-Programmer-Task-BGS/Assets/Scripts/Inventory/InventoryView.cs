using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Image _dragNDropImage;

        [SerializeField] private Image _detailsImage;
        [SerializeField] private TMP_Text _detailsText;
        [SerializeField] private TMP_Text _quoteText;

        private bool isDragging;

        private void Update()
        {
            if(isDragging)
            {
                _dragNDropImage.transform.position = Input.mousePosition;
            }
        }

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

        public void SetDragNDropImage(Sprite imageItem)
        {
            if(imageItem == null)
            {
                _dragNDropImage.gameObject.SetActive(false);
            
                isDragging = false;
            }
            else
            {
                _dragNDropImage.gameObject.SetActive(true);
                _dragNDropImage.sprite = imageItem;

                isDragging = true;
            }
        }
    }
}