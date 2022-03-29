using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_Spiral : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    public float rotSpeed = 1;
    float angle;
    void Update()
    {
        angle += 180 * rotSpeed * Time.deltaTime;
        rb.MoveRotation(Quaternion.Euler(0, angle, 0));
    }

}
