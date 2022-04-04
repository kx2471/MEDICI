using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 스페이스바를 누르면 카메라를 1동안 흔들고싶다.
        if (Input.GetButtonDown("Jump"))
        {
            Shake(1);
        }
    }

    public void Shake(float time)
    {
        StartCoroutine("IEShake", time);
    }


    public float kAdjust = 1;
    IEnumerator IEShake(float time)
    {
        Vector3 origin = Vector3.zero;
        // time초 동안 화면을 흔들고싶다.
        for (float t = 0; t <= time; t += Time.deltaTime)
        {
            transform.localPosition = origin + Random.insideUnitSphere * kAdjust;
            yield return 0;
        }
        // 다 흔들고 나면 원래위치로 돌려놓고싶다.
        transform.localPosition = origin;
    }
}
