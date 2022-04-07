using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOThrow : MonoBehaviour
{

    public GameObject BallFactory;
    public Transform ThrowPosition;

    public float ThrowPower = 30f;
    public bool canFire = true;
    public const float fireDelay = 1.5f;
    float fireTimer = 0;


    public Animator anim;

    void Start()
    {

    }

    void Update()
    {
        
        if (canFire)
        {

            
            if (fireTimer > fireDelay && Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Throwing");
                GameObject Ball = Instantiate(BallFactory);
                Ball.transform.position = ThrowPosition.position;



                Quaternion q = ThrowPosition.rotation * Quaternion.Euler(-40, 0, 0);
                Ball.transform.rotation = q;

                Destroy(Ball, 20f);


                //Rigidbody rb = Ball.GetComponent<Rigidbody>();

                //rb.AddForce(Camera.main.transform.forward * ThrowPower, ForceMode.Impulse);
                fireTimer = 0;

                
            }
            fireTimer += Time.deltaTime;

        }
    }

}