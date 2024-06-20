using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour
{
    [SerializeField] private Canvas instructionsCanvas;  // Referência ao Canvas de instruções

    private void Start()
    {
        // Garante que o cursor esteja visível e não travado
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Verifica se o botão esquerdo do mouse foi clicado
        {
            StartMinigame();
        }
    }

    private void StartMinigame()
    {
        instructionsCanvas.gameObject.SetActive(false);

        // Você pode adicionar qualquer código necessário para iniciar o minigame aqui
        // Por exemplo, ativar scripts ou objetos que controlam o minigame
    }
}

