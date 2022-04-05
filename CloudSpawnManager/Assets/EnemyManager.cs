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
    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();


        print(col.bounds.size);
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
            Vector3 pos;
            if(GetPosition(out pos))
            {
                enemy.transform.position = pos;
            }
            // 5. 현재시간을 0으로 초기화 해야한다.
            currentTime = 0;
            // 6. 생성시간을 생성직후에 랜덤으로 정하고싶다.
            createTime = Random.Range(min, max);
        }
    }

    private bool GetPosition(out Vector3 pos)    
    {
        pos = transform.position;
        //내 위치를 기준으로 임의의 x y z를 정하고싶다.

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
        //그 점에서 땅을 바라보고 싶다.
        // 닿은것이 있다면 그 위치에 Enemy를 생성해서 배치하고 싶다.
        
            pos = Vector3.zero;
            return false;
        
    }
}