using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSORandomSpawn : MonoBehaviour
{

    public float currentTime;
    public float createTime;
    public float max = 250;
    public float min = 100;
    public GameObject rainEscape;
    public GameObject Flame1;
    public GameObject rainManager;


    public GameObject rainFactory;
    // Start is called before the first frame update
    void Start()
    {

        RandomTime();
        currentTime = 0;
        rainEscape.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Flame1.activeSelf == true)
        {
            Destroy(rainManager);
            Destroy(rainEscape);
        }

        currentTime += Time.deltaTime;


        if (currentTime > createTime)
        {

            //Invoke 사용했을 때
            //Invoke("SpawnObject", 5f);//rainEffect 생성 5초 지연

            //Invoke("UIdestroy", 5f);

            rainEscape.SetActive(true);
            StartCoroutine(SpawnObject(5.0f));
            StartCoroutine(UmbrellaActivefalse(16.0f));

            RandomTime();
            print(createTime);
            currentTime = 0;
        }


    }




    IEnumerator SpawnObject(float num)
    {
        yield return new WaitForSeconds(num);
        Instantiate(rainFactory, transform.position, rainFactory.transform.rotation);
        rainEscape.SetActive(false);

    }
    IEnumerator UmbrellaActivefalse(float num)
    {
        yield return new WaitForSeconds(num);
        if (UmbrellaActive.instance.Umbrella.activeSelf == true)
        {
            UmbrellaActive.instance.Umbrella.SetActive(false);
        }
    }
    //void SpawnObject()
    //{
    //    Instantiate(rainFactory, transform.position, rainFactory.transform.rotation);
    //}
    //void UIdestroy()
    //{
    //    rainEscape.SetActive(false);
    //}

    void RandomTime()
    {
        createTime = Random.Range(min, max);
    }


}
