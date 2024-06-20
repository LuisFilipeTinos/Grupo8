using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour
{
    [SerializeField] private Canvas instructionsCanvas;  // Refer�ncia ao Canvas de instru��es

    private void Start()
    {
        // Garante que o cursor esteja vis�vel e n�o travado
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Verifica se o bot�o esquerdo do mouse foi clicado
        {
            StartMinigame();
        }
    }

    private void StartMinigame()
    {
        instructionsCanvas.gameObject.SetActive(false);

        // Voc� pode adicionar qualquer c�digo necess�rio para iniciar o minigame aqui
        // Por exemplo, ativar scripts ou objetos que controlam o minigame
    }
}

