using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    Vector2 cursorPos;
    RectTransform rectTransform;
    Canvas canvas;

    void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();

        canvas = GetComponentInParent<Canvas>();
    }
    // Update is called once per frame
    void Update()
    {
        //cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,Input.mousePosition,canvas.worldCamera,out cursorPos);
    }
    private void LateUpdate()
    {
        //transform.position = new Vector2(cursorPos.x, cursorPos.y);
        rectTransform.anchoredPosition = cursorPos;
    }
}
