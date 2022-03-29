using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOPlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
    }

    
}
