using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSORainManager : MonoBehaviour
{

    //생성시간
    float currentTime;
    float createTime = 1;
    public float min = 1;
    public float max = 2;
    public GameObject enemyFactory;


    // Start is called before the first frame update
    void Start()
    {
        // 태어날때 생성시간을 랜덤으로 정하고싶다.
        // 생성시간 = 랜덤(min, max)
        createTime = Random.Range(min, max);

    }

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 현재시간이 생성시간을 초과하면
        if (currentTime > createTime)
        {
            GameObject EnemyRain = Instantiate(enemyFactory);

            // 3. 적공장에서 적을 만들어서 내 위치에 배치하고 싶다.
            EnemyRain.transform.position = transform.position;
            // 4. 내 위치에 배치하고 싶다.
            // 5. 현재시간을 0으로 초기화 해야 한다.
            currentTime = 0;
            // 생성시간을 랜덤으로 정하고 싶다.
            createTime = Random.Range(min, max);
        }
    }
}