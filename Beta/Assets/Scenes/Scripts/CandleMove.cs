using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            transform.rotation = Quaternion.Euler(15, 0, 90);
            print("j");
        }
    }
}
