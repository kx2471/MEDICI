using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 입력에따라 상하좌우로 이동하고싶다.
public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public float rotSpeed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        // 1 사용자의 입력에따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2 상하로 방향을 만들고
        Vector3 dir = transform.up * v;
        dir.Normalize();
        // 3 그 방향으로 이동하고싶다. P = P0 + vt => P += vt
        transform.position += dir * speed * Time.deltaTime;
        transform.Rotate(Vector3.back, h * rotSpeed * 360 * Time.deltaTime);
    }
}
