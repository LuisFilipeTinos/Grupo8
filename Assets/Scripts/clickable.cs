using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickable : MonoBehaviour
{
    [SerializeField] float initiallimitY;
    [SerializeField] float finallimitY;

    [SerializeField] float initiallimitX;
    [SerializeField] float finallimitX;

    float x, y;

    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnMouseDown()
    {
        gameController.ObjetoClicado(gameObject);

        {
            x = UnityEngine.Random.Range(initiallimitX, finallimitX);
            y = UnityEngine.Random.Range(initiallimitY, finallimitY);
            transform.position = new Vector2(x, y);

        }

        if (gameObject.name == "ObjetoErrado")
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");

        SceneManager.LoadScene(2);
    }

}