using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간마다 적공장에서 적을 만들어서 내 위치에 배치하고싶다.
public class EnemyManager : MonoBehaviour
{
    public float delayTime = 10;
    public float createTime = 1;
    public Transform enemyParent;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        ObjectPool.instance.CreateInstance("Enemy", enemyParent, 10);
        if (delayTime > 0)
        {
            yield return new WaitForSeconds(delayTime);
        }
        while (true)
        {
            // 일정시간마다 적공장에서 적을 만들어서
            GameObject enemy = ObjectPool.instance.GetInactiveBullet("Enemy");
            // 내 위치에 배치하고싶다.
            enemy.transform.position = transform.position;
            yield return new WaitForSeconds(createTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
