using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{ 

    [SerializeField] float initiallimitY;
    [SerializeField] float finallimitY;

    [SerializeField] float initiallimitX;
    [SerializeField] float finallimitX;

    float x, y;

    // Start is called before the first frame update
    void Start()
    {
        x = UnityEngine.Random.Range(initiallimitX, finallimitX);
        y = UnityEngine.Random.Range(initiallimitY, finallimitY);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(x,y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
