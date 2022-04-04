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
        // �����̽��ٸ� ������ ī�޶� 1���� ����ʹ�.
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
        // time�� ���� ȭ���� ����ʹ�.
        for (float t = 0; t <= time; t += Time.deltaTime)
        {
            transform.localPosition = origin + Random.insideUnitSphere * kAdjust;
            yield return 0;
        }
        // �� ���� ���� ������ġ�� ��������ʹ�.
        transform.localPosition = origin;
    }
}
