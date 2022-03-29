using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSORainManager : MonoBehaviour
{

    //�����ð�
    public float creatTime = 1;
    //����ð�
    float currentTime = 0;
    //������
    public GameObject enemyFactory;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //1. �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;


        //2. ���� ����ð��� �����ð��� �ʰ��ϸ�
        if (currentTime > creatTime)
        {

            //3. �����ð����� �����忡�� ���� ���� �� ��ġ�� ������ ���� �ʹ�
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            //4. ����ð��� 0���� �ʱ�ȭ �ϰ�ʹ�.
            currentTime = 0;
        }







    }
}