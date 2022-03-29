using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperAir : MonoBehaviour
{
    public float force = 1;
    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * force, ForceMode.Impulse);
        }
    }
}
