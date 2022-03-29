using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSORainManager : MonoBehaviour
{

    //�����ð�
    float currentTime;
    float createTime = 1;
    public float min = 1;
    public float max = 2;
    public GameObject enemyFactory;


    // Start is called before the first frame update
    void Start()
    {
        // �¾�� �����ð��� �������� ���ϰ�ʹ�.
        // �����ð� = ����(min, max)
        createTime = Random.Range(min, max);

    }

    // Update is called once per frame
    void Update()
    {
        // 1. �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;
        // 2. ����ð��� �����ð��� �ʰ��ϸ�
        if (currentTime > createTime)
        {
            GameObject EnemyRain = Instantiate(enemyFactory);

            // 3. �����忡�� ���� ���� �� ��ġ�� ��ġ�ϰ� �ʹ�.
            EnemyRain.transform.position = transform.position;
            // 4. �� ��ġ�� ��ġ�ϰ� �ʹ�.
            // 5. ����ð��� 0���� �ʱ�ȭ �ؾ� �Ѵ�.
            currentTime = 0;
            // �����ð��� �������� ���ϰ� �ʹ�.
            createTime = Random.Range(min, max);
        }
    }
}