using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CollisionControllerMateriaisVidro : MonoBehaviour
{
  
        private void OnCollisionEnter2D(Collision2D collision)
        {

               switch (collision.gameObject.tag)
                {
                    case "Vidro":
                        Destroy(gameObject);
                        break;
                    case "Metal":
                        Destroy(gameObject);
                        //Link para aba de perca de pontos
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
