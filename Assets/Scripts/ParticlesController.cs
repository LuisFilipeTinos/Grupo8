using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] ParticleSystem movimentParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;


    [Range(0,0.2f)]
    [SerializeField] float dustFormationPeriod;
    [SerializeField] Rigidbody2D SpraySquare;

    float counter;
    
    void Update()
    {
        counter += Time.deltaTime;

        if (Mathf.Abs(SpraySquare.velocity.x) > occurAfterVelocity )
        {
            if (counter > dustFormationPeriod)
            {
                movimentParticle.Play();
                counter = 0;
            }
        }
    }


}
