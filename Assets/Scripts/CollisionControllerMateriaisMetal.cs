using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControllerMateriaisMetal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Vidro":
                Destroy(gameObject);
                //Link para aba de perca de pontos
                break;
            case "Metal":
                Destroy(gameObject);
                break;
            case "Plastico":
                Destroy(gameObject);
                //Link para aba de perca de pontos
                break;
            case "Papel":
                Destroy(gameObject);
                //Link para aba de perca de pontos
                break;
        }
    }
}
