using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoController : MonoBehaviour
{
    [SerializeField] float initialLimitY;
    [SerializeField] float finalLimitY;

    [SerializeField] float initialLimitX;
    [SerializeField] float finalLimitX;

    [SerializeField] GameObject targetGameObject;
    [SerializeField] float speed;

    float time = 0;

    float x, y;

    void Start()
    {
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {


        //time += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed);

        if (transform.position == targetGameObject.transform.position)
        {
            x = UnityEngine.Random.Range(initialLimitX, finalLimitX);
            y = UnityEngine.Random.Range(initialLimitY, finalLimitY);

            targetGameObject.transform.position = new Vector2(x, y);
        }

        //else
        //{
        //    x = 10.65f;
        //    y = 0.32f;

        //    targetGameObject.transform.position = new Vector2(x, y);

        //    transform.position = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed);
        //}

    }
    void StartMovement()
    {
        x = UnityEngine.Random.Range(initialLimitX, finalLimitX);
        y = UnityEngine.Random.Range(initialLimitY, finalLimitY);

        targetGameObject.transform.position = new Vector2(x, y);
    }
}