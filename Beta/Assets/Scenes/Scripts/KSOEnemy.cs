using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSOEnemy : MonoBehaviour
{

    public float speed = 5;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        // 태어날때 이동방향을 정하고싶다. 
      
 
           
            dir = Vector3.down;


    }
    // Update is called once per frame
    void Update()
    {
        // 살아가면서 그 정한 방향으로 이동하고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 너죽고 
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
