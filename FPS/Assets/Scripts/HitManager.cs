using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ImageHit게임오브젝트를 보였다가 0.1초후에 안보이게하는 기능을 만들고싶다.
public class HitManager : MonoBehaviour
{
    // 싱글톤으로 만드세요!!
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
    // ImageHit게임오브젝트를 보였다가 0.1초후에 안보이게하는 기능을 만들고싶다.
    public void DoHitPlz()
    {
        StopCoroutine("IEDoHit");
        StartCoroutine("IEDoHit");
    }

    IEnumerator IEDoHit()
    {
        // 보이게한다.
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        // 안보이게한다.
        imageHit.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
