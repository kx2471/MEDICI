using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame1State : MonoBehaviour

{

    public GameObject Flame1;


    
    private void OnCollisionEnter(Collision collision)
    {
        // �ʰ� "BridgeEdge"�� ������ 
        if (collision.gameObject.name.Contains("BridgeEdge"))
        {
            // Flame1�� ������.
            
            Flame1.SetActive(true);
            print("turn on");
        }
    }

 
}