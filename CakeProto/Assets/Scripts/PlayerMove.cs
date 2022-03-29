using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 20;
    public float jumpPower = 10f;

    private bool IsJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!IsJumping)
            {

                IsJumping=true;
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }

            else
            {
                return;
            }
        }
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);
        
      

        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Vector3 dir = transform.position - collision.contacts[0].point;
            dir.Normalize();
            rb.AddForce(dir * 5, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }
}
