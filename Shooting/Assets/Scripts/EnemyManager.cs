using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간마다 적공장에서 적을 만들어서 내 위치에 가져다 놓고싶다.
public class EnemyManager : MonoBehaviour
{
    // 생성시간
    public float createTime = 1;
    // 현재시간
    float currentTime = 0;
    // 적공장
    public GameObject enemyFactory;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1. 현재시간이 증가하다가 
        currentTime += Time.deltaTime;
        // 2. 만약 현재시간이 생성시간을 초과하면
        if (currentTime > createTime)
        {
            // 만약 게임오버가 되지 않았다면
            // => GameOverUI가 비활성화 되었다면
            if (false == GameManager.instance.GameOverUI.activeSelf)
            {
                // 3. 적공장에서 적을 만들어서
                GameObject enemy = Instantiate(enemyFactory);
                // 4. 내 위치에 가져다 놓고싶다. -> enemy의 위치 = 내 위치
                enemy.transform.position = transform.position;
            }
            // 5. 현재시간을 0으로 초기화 하고싶다.
            currentTime = 0;
        }

    }
}
