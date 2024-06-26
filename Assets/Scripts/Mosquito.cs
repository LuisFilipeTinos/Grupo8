using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        var x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        var y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        rb2d.velocity = new Vector2 (x * speed, y * speed);

    }

}
   
