using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOOnParticleCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {


        
        Transform tr = other.transform.Find("Fire");
        if (tr)
        {

            Destroy(tr.gameObject);
        }
    }


    void Update()
    {
        Destroy(gameObject, 10f);
    }

}

