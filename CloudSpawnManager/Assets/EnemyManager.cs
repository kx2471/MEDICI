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
    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();


        print(col.bounds.size);
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
            Vector3 pos;
            if(GetPosition(out pos))
            {
                enemy.transform.position = pos;
            }
            // 5. ����ð��� 0���� �ʱ�ȭ �ؾ��Ѵ�.
            currentTime = 0;
            // 6. �����ð��� �������Ŀ� �������� ���ϰ�ʹ�.
            createTime = Random.Range(min, max);
        }
    }

    private bool GetPosition(out Vector3 pos)    
    {
        pos = transform.position;
        //�� ��ġ�� �������� ������ x y z�� ���ϰ�ʹ�.

        Vector3 min = col.bounds.min;
        Vector3 max = col.bounds.max;

        float lx = 0 - col.bounds.size.x /  2;
        float rx = 0 + col.size.x / 2;
       
        float bz = 0 - col.size.z / 2;
        float fz = 0 + col.size.z / 2;

        pos.x += Random.Range(lx, rx);
        pos.z += Random.Range(bz, fz);

        Ray ray = new Ray(pos, Vector3.down);
        RaycastHit hitinfo;

        if(Physics.Raycast(ray, out hitinfo))
        {
            print(hitinfo.transform.name);
            pos = hitinfo.point;
            return true;
        }
        //�� ������ ���� �ٶ󺸰� �ʹ�.
        // �������� �ִٸ� �� ��ġ�� Enemy�� �����ؼ� ��ġ�ϰ� �ʹ�.
        
            pos = Vector3.zero;
            return false;
        
    }
}