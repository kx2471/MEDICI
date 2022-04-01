using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 위로 이동하고싶다.
public class Bullet : MonoBehaviour
{
    public float speed = 10;
  
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
