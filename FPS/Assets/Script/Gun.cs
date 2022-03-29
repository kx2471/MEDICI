using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���콺 ���� ��ư�� ������ �ٶ� ���� �Ѿ��ڱ��� �����ʹ�.

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject blmpactFactory;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���콺 ���ʹ�ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            //����ī�޶� �ٶ� ���� �Ѿ��ڱ��� �����ʹ�.
            //�ü�, �ٶ󺸴�, �������� ����

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitinfo;
            if(Physics.Raycast(ray, out hitinfo))
            {
                print(hitinfo.transform.name);
                // �Ѿ��ڱ��� �ε��� ���� ����� �ʹ�.
                GameObject bimpact = Instantiate(blmpactFactory);
                bimpact.transform.position = hitinfo.point;
                bimpact.transform.forward = hitinfo.normal;
            }

        
        
        
        }

    }

}
