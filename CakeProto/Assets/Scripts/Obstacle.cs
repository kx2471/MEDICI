using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public float rotSpeed = 1;
    float angle;
    // Update is called once per frame
    void Update()
    {
        angle += 360 * rotSpeed * Time.deltaTime;
        rb.MoveRotation(Quaternion.Euler(0, angle, 0));
    }

   
}
