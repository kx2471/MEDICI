using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� �Է¿����� �����¿�� �̵��ϰ�ʹ�.
public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public float rotSpeed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        // 1 ������� �Է¿�����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2 ���Ϸ� ������ �����
        Vector3 dir = transform.up * v;
        dir.Normalize();
        // 3 �� �������� �̵��ϰ�ʹ�. P = P0 + vt => P += vt
        transform.position += dir * speed * Time.deltaTime;
        transform.Rotate(Vector3.back, h * rotSpeed * 360 * Time.deltaTime);
    }
}
