using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide: MonoBehaviour
{
    private void OnMouseDown()
    {
        // Torna o objeto invis�vel ao ser clicado
        gameObject.SetActive(false);
    }
}