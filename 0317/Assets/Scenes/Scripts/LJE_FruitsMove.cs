using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_FruitsMove : MonoBehaviour
{
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }



// Update is called once per frame

    void FixedUpdate()
    {
     
    }
    
    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.name.Contains("Bullet"))

        {
            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = true;
            rigid.AddForce(Vector3.down);

            // rigid.velocity = Vector3.down;
            // rigid.AddForce(Vector3.forward * 30);
            // rigid.AddForce(Vector3.back * 30);

            print("BBB");


        }

        //else
        //{
           // rigid.isKinematic = true;
        //}
    }
}
