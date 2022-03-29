using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController cc;


    public float jumpPower = 10;
    public float gravity = -9.81f;
    float yVelocity;


    int jumpCount;
    public int MaxjumpCount = 2;


    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //if((cc.collisionFlags & CollisionFlags.Below) !=0) 
        if(cc.isGrounded)
        {
            jumpCount = 0;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

       
            if (jumpCount < MaxjumpCount && Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpPower;
                jumpCount++;
            }
       
        


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        dir.Normalize();
        Vector3 velocity = dir * speed;

        velocity.y = yVelocity;



        cc.Move(velocity * Time.deltaTime);
            

    }
}
