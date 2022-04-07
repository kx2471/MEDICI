using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_PlayerDetect : MonoBehaviour
{
    public GameObject[] flames;
    Rigidbody rb;
    bool fireStart;
    float fireTime = 1;
    float currentTime;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float radius = 3;
    public LayerMask layerMask;



    private void Update()
    {
        if(fireStart)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= fireTime)
            {
                flames[count++].SetActive(true);
                currentTime = 0;
                if (count >= flames.Length) fireStart = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, layerMask);
        if(cols.Length > 0)
        {
            fireStart = true;
        }
    }
}
