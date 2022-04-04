using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 위로 이동하고싶다.
public class Bullet : MonoBehaviour
{
    // 속력
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 위 방향으로
        Vector3 dir = transform.up;
        // 이동하고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }
}
