using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    Vector2 cursorPos;

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void LateUpdate()
    {
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}
