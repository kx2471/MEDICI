using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 게임오브젝트가 ObjectPool에서 관리하는 녀석이라면
        if (ObjectPool.IsObjectPoolObject(other.gameObject))
        {
            // 비활성 목록에 추가하고싶다.
            ObjectPool.instance.AddInactiveList(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
