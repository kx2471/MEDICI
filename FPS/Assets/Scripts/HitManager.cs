using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ImageHit���ӿ�����Ʈ�� �����ٰ� 0.1���Ŀ� �Ⱥ��̰��ϴ� ����� �����ʹ�.
public class HitManager : MonoBehaviour
{
    // �̱������� ���弼��!!
    public static HitManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject imageHit;
    void Start()
    {
        imageHit.SetActive(false);
    }
    // ImageHit���ӿ�����Ʈ�� �����ٰ� 0.1���Ŀ� �Ⱥ��̰��ϴ� ����� �����ʹ�.
    public void DoHitPlz()
    {
        StopCoroutine("IEDoHit");
        StartCoroutine("IEDoHit");
    }

    IEnumerator IEDoHit()
    {
        // ���̰��Ѵ�.
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        // �Ⱥ��̰��Ѵ�.
        imageHit.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
