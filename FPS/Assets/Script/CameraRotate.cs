using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 마우스를 움직이면 카메라를 회전하고싶다.
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
        // 1. 사용자가 마우스를 움직이면
        float mx = Input.GetAxis("Mouse X"); // 움직임의 변화량
        float my = Input.GetAxis("Mouse Y");
        rx += my * rotSpeed * Time.deltaTime;
        ry += mx * rotSpeed * Time.deltaTime;

        rx = Mathf.Clamp(rx, -70, 70);
        // 2. 카메라를 회전하고싶다.
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
