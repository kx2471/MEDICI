using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목적지를 향해서 이동하고싶다.
public class Tail : MonoBehaviour
{
    // 속력
    public float speed = 4;
    // 목적지
    public GameObject target;

    void Start()
    {
    }

    void Update()
    {
        // 1. 목적지를 향하는 방향을 만들고
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // 2. 그 방향으로 이동하고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }
}
