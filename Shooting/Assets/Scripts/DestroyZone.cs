using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 상대를 파괴하고싶다.
        Destroy(other.gameObject);
    }
}
