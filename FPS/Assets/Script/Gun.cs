using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//마우스 왼쪽 버튼을 누르면 바라본 곳에 총알자국을 남기고싶다.

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
        //만약 마우스 왼쪽버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            //메인카메라가 바라본 곳에 총알자국을 남기고싶다.
            //시선, 바라보다, 닿은곳의 정보

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitinfo;
            if(Physics.Raycast(ray, out hitinfo))
            {
                print(hitinfo.transform.name);
                // 총알자국을 부딪힌 곳에 남기고 싶다.
                GameObject bimpact = Instantiate(blmpactFactory);
                bimpact.transform.position = hitinfo.point;
                bimpact.transform.forward = hitinfo.normal;
            }

        
        
        
        }

    }

}
