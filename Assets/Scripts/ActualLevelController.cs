using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualLevelController : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
