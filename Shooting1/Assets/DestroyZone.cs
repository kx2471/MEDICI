using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //�ε�ģ ��븦 �ı��ϰ�ʹ�
        Destroy(other.gameObject);
    }

}
