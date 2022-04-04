using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.AddTorque(transform.right * 20, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
