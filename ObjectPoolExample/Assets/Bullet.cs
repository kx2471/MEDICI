using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �̵��ϰ�ʹ�.
public class Bullet : MonoBehaviour
{
    public float speed = 10;
  
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
