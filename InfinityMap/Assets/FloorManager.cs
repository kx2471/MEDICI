using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ư���������� �̵��ϰ�ʹ�.
// ���� �ֱٿ� ������� Floor�� Docker��ġ�� �����ð����� Floor�� �ٿ��ְ�ʹ�. Floor�� ���� �ڽ����� �ϰ�ʹ�.
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
                // 1. Floor���忡�� Floor�� �ϳ� �����
                GameObject floor = Instantiate(floorFactory);
                // 2. ���� �ֱٿ� ������� Floor�� Docker��ġ�� ��ġ�ϰ�ʹ�.
                floor.transform.position = latestFloor.docker.position;
                // 3. Floor�� ���� �ڽ����� �ϰ�ʹ�. ���� �θ� = ��
                floor.transform.parent = transform;
                // 4. ���θ��� floor�� latestFloor�� �����ϰ�ʹ�.
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
        // Ư���������� �̵��ϰ�ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }
}
