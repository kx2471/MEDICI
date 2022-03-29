using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSORainManager : MonoBehaviour
{

    //생성시간
    public float creatTime = 1;
    //현재시간
    float currentTime = 0;
    //적공장
    public GameObject enemyFactory;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //1. 시간이 흐르다가
        currentTime += Time.deltaTime;


        //2. 만약 현재시간이 생성시간을 초과하면
        if (currentTime > creatTime)
        {

            //3. 일정시간마다 적공장에서 적을 만들어서 내 위치에 가져다 놓고 싶다
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            //4. 현재시간을 0으로 초기화 하고싶다.
            currentTime = 0;
        }







    }
}