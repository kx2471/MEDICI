using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ð����� �����忡�� ���� ���� Spawn����߿� ���Ƿ� �ϳ��� �����ؼ� �� ��ġ�� �����ϰ�ʹ�.
// �����ð��� �������Ŀ� �������� ���ϰ�ʹ�.
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
        // �¾�� �����ð��� �������� ���ϰ�ʹ�.
        // �����ð� = ����(min, max)
        createTime = Random.Range(min, max);
    }
    int preRandomIndex = -1;
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
            // 4. spawnlist�� ������ ��ġ�� ��ġ�ϰ�ʹ�.
            int randomIndex = Random.Range(0, spawnList.Length);
            // ���� randomIndex�� preRandomIndex�� ���ٸ� 
            if (randomIndex == preRandomIndex)
            {
                // randomIndex�� �ٽ� ���ϰ�ʹ�.
                randomIndex = (randomIndex + 1) % spawnList.Length;
            }

            Vector3 pos = spawnList[randomIndex].position;
            enemy.transform.position = pos;
            // 5. ����ð��� 0���� �ʱ�ȭ �ؾ��Ѵ�.
            currentTime = 0;
            // 6. �����ð��� �������Ŀ� �������� ���ϰ�ʹ�.
            createTime = Random.Range(min, max);
            preRandomIndex = randomIndex;
        }
    }
}
