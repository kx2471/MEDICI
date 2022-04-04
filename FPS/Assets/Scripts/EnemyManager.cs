using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ð����� �����忡�� ���� ���� �� ��ġ�� ��ġ�ϰ�ʹ�.
// �����ð��� �������Ŀ� �������� ���ϰ�ʹ�.
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
        // �¾�� �����ð��� �������� ���ϰ�ʹ�.
        // �����ð� = ����(min, max)
        createTime = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        // 1. ����ð��� �帣�ٰ�
        currentTime += Time.deltaTime;
        // 2. ���� ����ð��� �����ð��� �ʰ��ϸ�
        if (currentTime > createTime)
        {
            // 3. �����忡�� ���� ����
            GameObject enemy = Instantiate(enemyFactory);
            // 4. �� ��ġ�� ��ġ�ϰ�ʹ�. enemy = ����ġ
            enemy.transform.position = transform.position;
            // 5. ����ð��� 0���� �ʱ�ȭ �ؾ��Ѵ�.
            currentTime = 0;
            // 6. �����ð��� �������Ŀ� �������� ���ϰ�ʹ�.
            createTime = Random.Range(min, max);
        }
    }
}
