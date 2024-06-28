using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderHitController : MonoBehaviour
{
    [SerializeField] CircleCollider2D colliderHit;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            colliderHit.enabled = true;
        else
            colliderHit.enabled = false;
        
    }
}
