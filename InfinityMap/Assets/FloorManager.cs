using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 특정방향으로 이동하고싶다.
// 가장 최근에 만들어진 Floor의 Docker위치에 일정시간마다 Floor를 붙여주고싶다. Floor를 나의 자식으로 하고싶다.
public class FloorManager : MonoBehaviour
{
    public Vector3 dir = Vector3.back;
    public float speed = 5;

    public Floor latestFloor;
    public float createTime = 1;
    public int count;
    public int maxCount = 20;
    public GameObject floorFactory;
    IEnumerator Start()
    {
        while (true)
        {
            if (count < maxCount)
            {
                // 1. Floor공장에서 Floor를 하나 만들고
                GameObject floor = Instantiate(floorFactory);
                // 2. 가장 최근에 만들어진 Floor의 Docker위치에 배치하고싶다.
                floor.transform.position = latestFloor.docker.position;
                // 3. Floor를 나의 자식으로 하고싶다. 나의 부모 = 너
                floor.transform.parent = transform;
                // 4. 새로만든 floor를 latestFloor로 갱신하고싶다.
                latestFloor = floor.GetComponent<Floor>();
                latestFloor.floorManager = this;
                count++;
            }
            yield return new WaitForSeconds(createTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 특정방향으로 이동하고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }
}
