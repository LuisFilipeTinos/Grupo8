using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TapToStartController : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
       
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Time.timeScale = 1;

            GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag("TapStart");

            foreach (GameObject obj in objectsToRemove)
            {
                Destroy(obj);
            }
        }

    }
}
