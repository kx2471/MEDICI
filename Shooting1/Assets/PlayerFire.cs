using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����ڰ� ���콺 ���� ��ư�� ������ �Ѿ��� �ѱ� ��ġ�� ���ٳ���ʹ�
public class PlayerFire : MonoBehaviour
{

    //�ѱ���ġ
    public GameObject firePosition;

    //�Ѿ�
    public GameObject bulletFactory;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1. ���� ����ڰ� ���콺 ���ʹ�ư��������
        if (Input.GetButtonDown("Fire1"))
        {

            //2. �Ѿ˰��忡�� �Ѿ��� ����
            GameObject bullet = Instantiate(bulletFactory);
            //3. �Ѿ��� �ѱ���ġ�� ������ ����ʹ�.
            bullet.transform.position = firePosition.transform.position;

        }


    }
}
