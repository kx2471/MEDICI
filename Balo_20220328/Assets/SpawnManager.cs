using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간마다 적공장에서 적을 만들어서 Spawn목록중에 임의로 하나를 선택해서 그 위치에 생성하고싶다.
// 생성시간을 생성직후에 랜덤으로 정하고싶다.
public class SpawnManager : MonoBehaviour
{
    float currentTime;
    float createTime = 1;
    public float min = 1;
    public float max = 3;
    public GameObject enemyFactory;
    public Transform[] spawnList;
    // Start is called before the first frame update
    void Start()
    {
        // 태어날때 생성시간을 랜덤으로 정하고싶다.
        // 생성시간 = 랜덤(min, max)
        createTime = Random.Range(min, max);
    }
    int preRandomIndex = -1;
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
            // 4. spawnlist의 임의의 위치에 배치하고싶다.
            int randomIndex = Random.Range(0, spawnList.Length);
            // 만약 randomIndex가 preRandomIndex와 같다면 
            if (randomIndex == preRandomIndex)
            {
                // randomIndex를 다시 정하고싶다.
                randomIndex = (randomIndex + 1) % spawnList.Length;
            }

            Vector3 pos = spawnList[randomIndex].position;
            enemy.transform.position = pos;
            // 5. 현재시간을 0으로 초기화 해야한다.
            currentTime = 0;
            // 6. 생성시간을 생성직후에 랜덤으로 정하고싶다.
            createTime = Random.Range(min, max);
            preRandomIndex = randomIndex;
        }
    }
}
