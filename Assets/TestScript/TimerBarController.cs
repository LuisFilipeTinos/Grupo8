using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;

public class TimerBarController : MonoBehaviour
{
    ActualLevelController actualLevelController;
    [SerializeField] GameObject timerBar;
    [SerializeField] int timeInSeconds;
    [SerializeField] int scaleTo;

    // Start is called before the first frame update
    void Start()
    {
        actualLevelController = GameObject.FindGameObjectWithTag("ActualLevelManager").GetComponent<ActualLevelController>();
        RunTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RunTimer()
    {
        if (actualLevelController.level > 2 && actualLevelController.level <= 4)
        {
            timeInSeconds = 20;
        }
        else if (actualLevelController.level > 4 && actualLevelController.level <= 6)
        {
            timeInSeconds = 17;
        }
        else if (actualLevelController.level > 6 && actualLevelController.level <= 8)
        {
            timeInSeconds = 14;
        }
        else if (actualLevelController.level > 8 && actualLevelController.level <= 15)
        {
            timeInSeconds = 11;
        }
        else if (actualLevelController.level > 15 && actualLevelController.level <= 20)
        {
            timeInSeconds = 10;
        }
        else if (actualLevelController.level > 20 && actualLevelController.level <= 25)
        {
            timeInSeconds = 9;
        }
        else if (actualLevelController.level > 25 && actualLevelController.level <= 35)
        {
            timeInSeconds = 8;
        }
        else if (actualLevelController.level > 35 && actualLevelController.level <= 45)
        {
            timeInSeconds = 7;
        }
        else if (actualLevelController.level > 45 && actualLevelController.level <= 55)
        {
            timeInSeconds = 6;
        }

        LeanTween.scaleX(timerBar, scaleTo, timeInSeconds).setOnComplete(() => { SceneManager.LoadScene(6); });
    }
}
