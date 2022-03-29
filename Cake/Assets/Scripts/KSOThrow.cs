using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOThrow : MonoBehaviour
{

    public GameObject BallFactory;
    public GameObject ThrowPosition;

    public float ThrowPower = 15f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject Ball = Instantiate(BallFactory);
            Ball.transform.position = ThrowPosition.transform.position;


            Rigidbody rb = Ball.GetComponent<Rigidbody>();

            rb.AddForce(Camera.main.transform.forward * ThrowPower, ForceMode.Impulse);
        }


    }

}