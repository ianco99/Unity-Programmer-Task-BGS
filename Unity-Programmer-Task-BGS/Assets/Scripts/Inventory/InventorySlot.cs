using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ISlottable slottable;
    
    [SerializeField] private Image slotImage;
    [SerializeField] private GameObject blinkImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter " + gameObject.name);
        ToggleHover(true);
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit " + gameObject.name);
        ToggleHover(false);
        //throw new System.NotImplementedException();
    }
    
    private void ToggleHover(bool value)
    {
        blinkImage.SetActive(value);
    }
}