using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ���ӿ�����Ʈ�� ObjectPool���� �����ϴ� �༮�̶��
        if (ObjectPool.IsObjectPoolObject(other.gameObject))
        {
            // ��Ȱ�� ��Ͽ� �߰��ϰ�ʹ�.
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
