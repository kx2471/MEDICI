using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOEnemy : MonoBehaviour
{

    public float speed = 20;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {

     

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = -transform.up;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
        }
    }
}
