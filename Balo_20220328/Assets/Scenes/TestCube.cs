using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    void Update()
    {
        transform.position = dir * speed * Time.deltaTime;
    }
    //System.Action callback;
    //public void Move(Vector3 dir, System.Action callback)
    //{
    //    this.callback = callback;
    //    StartCoroutine("IEMove", dir);
    //}

    //IEnumerator IEMove(Vector3 dir)
    //{
    //    for(float t = 0; t <= 1; t += Time.deltaTime)
    //    {
    //        yield return 0;
    //    }
    //    if(callback != null)
    //    {
    //        callback();
    //    }
    //    transform.position += dir * speed * Time.deltaTime;
    //}
}
