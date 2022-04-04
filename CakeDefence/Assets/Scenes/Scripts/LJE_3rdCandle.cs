using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_3rdCandle : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame

    void FixedUpdate()
    {

    }
    public GameObject candlesupport;
    public GameObject Flame1;

    void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.name.Contains("Player"))
        {
            rb = GetComponent<Rigidbody>();
            candlesupport.SetActive(true);
            print("AAA");
        }
    
        if (other.gameObject.name.Contains("BridgeEdge"))
        {
            // rigid.velocity = new Vector3(0, 0, 0);
            rb.isKinematic = true;
            Flame1.SetActive(true);

            
            
            
            print("ZZZ");
        }
    }
        

}