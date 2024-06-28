using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityOnFirstClick : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;  // O objeto cuja visibilidade ser� alternada
    [SerializeField] private GameObject secondObject;
    private bool hasToggled = false;

    void Update()
    {
        if (!hasToggled && Input.GetMouseButtonDown(0))  // Verifica se o bot�o esquerdo do mouse foi clicado e se ainda n�o foi alternado
        {
            ToggleObject(targetObject);
            if (secondObject != null)
            {
                ToggleObject(secondObject);
            }
            hasToggled = true;  // Marca como alternado para n�o responder a cliques subsequentes
        }
    }

    private void ToggleObject(GameObject obj)
    {
        bool currentState = obj.activeSelf;
        obj.SetActive(!currentState);  // Alterna a visibilidade do objeto
    }
}
