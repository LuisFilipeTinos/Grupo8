using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class GameController : MonoBehaviour
{
    public GameObject objetoCorreto;
    public GameObject objetoCorreto2;
    public GameObject objetoCorreto3;
    public GameObject objetoCorreto4;
    public GameObject objetoErrado;
    public GameObject objetoErrado2;
    public GameObject objetoErrado3;
    public GameObject objetoErrado4;
    public TMP_Text contadorText;
    private int cliquesRestantes = 4;

    void Start()
    {
        AtualizarContador();
    }

    public void ObjetoClicado(GameObject objeto)
    {
        if (objeto == objetoErrado || objeto == objetoErrado2 || objeto == objetoErrado3 || objeto == objetoErrado4)
        {
            GameOver();
        }
        else if (objeto == objetoCorreto || objeto == objetoCorreto2 || objeto == objetoCorreto3 || objeto == objetoCorreto4)
        {
            cliquesRestantes--;
            AtualizarContador();

            if (cliquesRestantes <= 0)
            {
                ProximaFase();
            }
        }
    }

    private void AtualizarContador()
    {
        contadorText.text = "Objetos restantes: " + cliquesRestantes;
    }

    private void ProximaFase()
    {
        Debug.Log("Próxima fase!");
        // Carregar a próxima fase 
        //SceneManager.LoadScene(Random.Range(1, 3));

        var actualLevelIndex = SceneManager.GetActiveScene().buildIndex;
        var exclude = new HashSet<int>() { actualLevelIndex };
        var range = Enumerable.Range(1, 2).Where(x => !exclude.Contains(x));
        var rand = new System.Random();
        int index = rand.Next(0, 2 - exclude.Count);
        SceneManager.LoadScene(range.ElementAt(index));
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // Adicione a lógica de game over aqui, por exemplo, carregar uma cena de game over
        SceneManager.LoadScene(3);
    }
}
