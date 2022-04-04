using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KSOOnParticleCollision : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        Destroy(gameObject, 10f);
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            if (collisionEvents[i].colliderComponent.gameObject.name.Contains("Fire"))
            {
                Destroy(collisionEvents[i].colliderComponent.gameObject);
                KSOGameManager.instance.GameOverUI.SetActive(true);
            }
        }
    }


    //    void OnParticleCollision(GameObject other)
    //    {
    //            print(other.name);
    //        if (other.name.Contains("LJE_Player"))
    //        {
    //        }
    //        if (other.name.Contains("Fire"))
    //        {

    //            Destroy(other.transform.gameObject);
    //            KSOGameManager.instance.GameOverUI.SetActive(true);
    //        }
    //    }


    void Update()
    {
       
    }
}
