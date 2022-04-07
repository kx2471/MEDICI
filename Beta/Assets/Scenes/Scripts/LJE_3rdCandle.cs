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


    public GameObject candlesupport;
    public GameObject Flame1;

    void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.name.Contains("Player"))
        {
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.velocity = Vector3.right;
            
            // candlesupport.SetActive(true);
            
            print("AAA");
        }

        if (other.gameObject.name.Contains("BridgeEdge"))
        {
            // rigid.velocity = new Vector3(0, 0, 0);
            rb.isKinematic = true;
            Flame1.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezeAll; 




            print("ZZZ");
        }
    }


}