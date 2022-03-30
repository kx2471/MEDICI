using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSORandomSpawn : MonoBehaviour
{

    float currentTime;
    public GameObject rainFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.deltaTime;
        float newX = Random.Range(-56.7f, 65f), newY = Random.Range(58.6f, 58.7f), newZ = Random.Range(12f, 112f);

        Vector3 RandomPos = new Vector3(newX, newY, newZ);


        if (currentTime > 10)
        {
            Instantiate(rainFactory, RandomPos, Quaternion.identity);
            currentTime = 0;
            
        }
    }
}
