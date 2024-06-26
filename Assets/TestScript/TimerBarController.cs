using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;

public class TimerBarController : MonoBehaviour
{

    [SerializeField] GameObject timerBar;
    [SerializeField] int timeInSeconds;
    [SerializeField] int scaleTo;

    // Start is called before the first frame update
    void Start()
    {
        RunTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RunTimer()
    {
        LeanTween.scaleX(timerBar, scaleTo, timeInSeconds).setOnComplete(() => { SceneManager.LoadScene(6); });
    }
}
