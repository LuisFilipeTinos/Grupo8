using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour,IDragHandler
{
    private RectTransform rectTransform;

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/3;
        //transform.position = Input.mousePosition;
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}