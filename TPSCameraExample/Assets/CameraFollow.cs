using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public Transform target;
    public Transform lookTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position;
        //lookTarget에서 target방향을 바라보고 부딪힌것이 있다면
        Ray ray = new Ray(lookTarget.position, targetPosition - lookTarget.position);

        RaycastHit hitinfo;

        if(Physics.Raycast(ray, out hitinfo))
        {

            //그 위치가 targetPosition이 되게 하고 싶다.
            print(hitinfo.transform.name);
            targetPosition = hitinfo.point;
        }

        transform.position = Vector3.Lerp(transform.position, 
            targetPosition, Time.deltaTime * 10);
        transform.rotation = target.rotation;   

    }
}
