using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityOnFirstClick : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;  // O objeto cuja visibilidade será alternada
    private bool hasToggled = false;

    void Update()
    {
        if (!hasToggled && Input.GetMouseButtonDown(0))  // Verifica se o botão esquerdo do mouse foi clicado e se ainda não foi alternado
        {
            ToggleObject();
            hasToggled = true;  // Marca como alternado para não responder a cliques subsequentes
        }
    }

    private void ToggleObject()
    {
        bool currentState = targetObject.activeSelf;
        targetObject.SetActive(!currentState);  // Alterna a visibilidade do objeto
    }
}
