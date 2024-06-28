using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityOnFirstClick : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;  // O objeto cuja visibilidade será alternada
    [SerializeField] private GameObject secondObject;
    private bool hasToggled = false;

    void Update()
    {
        if (!hasToggled && Input.GetMouseButtonDown(0))  // Verifica se o botão esquerdo do mouse foi clicado e se ainda não foi alternado
        {
            ToggleObject(targetObject);
            if (secondObject != null)
            {
                ToggleObject(secondObject);
            }
            hasToggled = true;  // Marca como alternado para não responder a cliques subsequentes
        }
    }

    private void ToggleObject(GameObject obj)
    {
        bool currentState = obj.activeSelf;
        obj.SetActive(!currentState);  // Alterna a visibilidade do objeto
    }
}
