using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 마우스 왼쪽 버튼을 누르면 총알공장에서 총알을 만들어서 총구위치에 배치하고싶다.
public class PlayerFire : MonoBehaviour
{
    public Transform firePosition;
    public Transform bulletParent;

    private void Start()
    {
        // ObjectPool을 이용해서 총알을 20개 만들고싶다.
        ObjectPool.instance.CreateInstance("Bullet", bulletParent, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // 1 사용자가 마우스 왼쪽 버튼을 누르면
        if (Input.GetMouseButtonDown(0))
        {
            // 2 총알공장에서 총알을 만들어서
            GameObject bullet = ObjectPool.instance.GetInactiveBullet("Bullet");
            // 3 총구위치에 배치하고싶다.
            bullet.transform.position = firePosition.position;
            bullet.transform.up = firePosition.up;
        }
    }
}
