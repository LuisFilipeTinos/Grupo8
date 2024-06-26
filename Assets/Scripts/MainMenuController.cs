using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(Random.Range(1, 4));
    }
}
