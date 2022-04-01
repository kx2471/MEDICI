using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ð����� �����忡�� ���� ���� �� ��ġ�� ��ġ�ϰ�ʹ�.
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
            // �����ð����� �����忡�� ���� ����
            GameObject enemy = ObjectPool.instance.GetInactiveBullet("Enemy");
            // �� ��ġ�� ��ġ�ϰ�ʹ�.
            enemy.transform.position = transform.position;
            yield return new WaitForSeconds(createTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
