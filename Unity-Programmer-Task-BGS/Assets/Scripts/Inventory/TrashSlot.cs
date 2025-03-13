using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action<bool> OnHovering;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHovering?.Invoke(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnHovering?.Invoke(false);
    }
}
