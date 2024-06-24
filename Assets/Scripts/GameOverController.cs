using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public void Start()
    {
       var actualLevelController = GameObject.FindGameObjectWithTag("ActualLevelManager");
        actualLevelController.GetComponent<ActualLevelController>().level = 0;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
