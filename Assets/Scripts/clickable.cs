using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class clickable : MonoBehaviour, IPointerClickHandler
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

    private void GameOver()
    {
        Debug.Log("Game Over!");

        SceneManager.LoadScene(2);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameController.ObjetoClicado(gameObject);
 
        //x = UnityEngine.Random.Range(initiallimitX, finallimitX);
        //y = UnityEngine.Random.Range(initiallimitY, finallimitY);
        //transform.position = new Vector2(x, y);

        //if (gameObject.tag == "IncorrectObject")
        //{
        //    Destroy(this.gameObject);
        //    GameOver();
        //}
    }
}