using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ��븦 �ı��ϰ�ʹ�.
        Destroy(other.gameObject);
    }
}