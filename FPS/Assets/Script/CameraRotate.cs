using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ���콺�� �����̸� ī�޶� ȸ���ϰ�ʹ�.
public class CameraRotate : MonoBehaviour
{
    float rx;
    float ry;
    public float rotSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 1. ����ڰ� ���콺�� �����̸�
        float mx = Input.GetAxis("Mouse X"); // �������� ��ȭ��
        float my = Input.GetAxis("Mouse Y");
        rx += my * rotSpeed * Time.deltaTime;
        ry += mx * rotSpeed * Time.deltaTime;

        rx = Mathf.Clamp(rx, -70, 70);
        // 2. ī�޶� ȸ���ϰ�ʹ�.
        transform.eulerAngles = new Vector3(-rx, ry, 0);
    }

    //float Clamp(float value, float min, float max)
    //{
    //    if (value < min)
    //    {
    //        return min;
    //    }

    //    if (value > max)
    //    {
    //        return max;
    //    }

    //    return value;
    //}
}
