using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간마다 적공장에서 적을 만들어서 내 위치에 배치하고싶다.
// 생성시간을 생성직후에 랜덤으로 정하고싶다.
public class EnemyManager : MonoBehaviour
{
    float currentTime;
    float createTime = 1;
    public float min = 1;
    public float max = 3;
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
        // 1. 현재시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 만약 현재시간이 생성시간을 초과하면
        if (currentTime > createTime)
        {
            // 3. 적공장에서 적을 만들어서
            GameObject enemy = Instantiate(enemyFactory);
            // 4. 내 위치에 배치하고싶다. enemy = 내위치
            enemy.transform.position = transform.position;
            // 5. 현재시간을 0으로 초기화 해야한다.
            currentTime = 0;
            // 6. 생성시간을 생성직후에 랜덤으로 정하고싶다.
            createTime = Random.Range(min, max);
        }
    }
}
