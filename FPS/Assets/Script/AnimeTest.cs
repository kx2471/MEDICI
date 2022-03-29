using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeTest : MonoBehaviour
{
    // Start is called before the first frame update

    Animator Anime;

    void Start()
    {
        Anime = GetComponentInChildren<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Idle
            Anime.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Walk
            Anime.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Attack
            Anime.SetTrigger("Attack");
        }
    }
}
