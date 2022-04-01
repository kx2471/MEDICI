using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ���콺 ���� ��ư�� ������ �Ѿ˰��忡�� �Ѿ��� ���� �ѱ���ġ�� ��ġ�ϰ�ʹ�.
public class PlayerFire : MonoBehaviour
{
    public Transform firePosition;
    public Transform bulletParent;

    private void Start()
    {
        // ObjectPool�� �̿��ؼ� �Ѿ��� 20�� �����ʹ�.
        ObjectPool.instance.CreateInstance("Bullet", bulletParent, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // 1 ����ڰ� ���콺 ���� ��ư�� ������
        if (Input.GetMouseButtonDown(0))
        {
            // 2 �Ѿ˰��忡�� �Ѿ��� ����
            GameObject bullet = ObjectPool.instance.GetInactiveBullet("Bullet");
            // 3 �ѱ���ġ�� ��ġ�ϰ�ʹ�.
            bullet.transform.position = firePosition.position;
            bullet.transform.up = firePosition.up;
        }
    }
}
