using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOThrow : MonoBehaviour
{

    public GameObject BallFactory;
    public Transform ThrowPosition;

    public float ThrowPower = 30f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject Ball = Instantiate(BallFactory);
            Ball.transform.position = ThrowPosition.position;



            Quaternion q = ThrowPosition.rotation * Quaternion.Euler(-70, 0, 0);
            Ball.transform.rotation = q;


            //Rigidbody rb = Ball.GetComponent<Rigidbody>();

            //rb.AddForce(Camera.main.transform.forward * ThrowPower, ForceMode.Impulse);
        }


    }

}