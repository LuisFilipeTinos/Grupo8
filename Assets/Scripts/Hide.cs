using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide: MonoBehaviour
{
    private void OnMouseDown()
    {
        // Torna o objeto invisível ao ser clicado
        gameObject.SetActive(false);
    }
}