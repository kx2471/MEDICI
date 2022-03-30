using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpAddPotion : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            PlayerHP playerHP = other.GetComponent<PlayerHP>();
            if(playerHP != null)
            {
                playerHP.AddHP(1);
                Destroy(gameObject);
            }
        }
    }
    
}
