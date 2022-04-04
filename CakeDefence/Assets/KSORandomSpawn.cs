using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSORandomSpawn : MonoBehaviour
{

    float currentTime;
    float createTime;
    public float max = 250;
    public float min = 100;
    
    

    public GameObject rainFactory;
    // Start is called before the first frame update
    void Start()
    {
        RandomTime();
        currentTime = min;

    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            SpawnObject();
            RandomTime();
            print(createTime);
        }

        


    }
    void SpawnObject()
    {
        currentTime = 0;
        Instantiate(rainFactory, transform.position, rainFactory.transform.rotation);
    }

    void RandomTime()
    {
        createTime = Random.Range(min, max);
    }


}
