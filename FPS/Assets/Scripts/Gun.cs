using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 만약 마우스 왼쪽 버튼을 누르면
// 메인카메라가 바라본곳에 총알자국을 남기고싶다.
public class Gun : MonoBehaviour
{
    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        gunTargetPosision = zoomOutPos.localPosition;
    }

    public GameObject bImpactFactory;
    public GameObject bImpactForEnemyFactory;

    void Update()
    {
        UpdateZoom();
        UpdateFire();
    }
    public float zoomInValue = 15;
    public float zoomOutValue = 60;
    float targetZoomValue = 60;
    public Transform zoomInPos;
    public Transform zoomOutPos;
    public Transform gunObject;
    Vector3 gunTargetPosision;
    private void UpdateZoom()
    {
        // 만약 마우스 오른쪽 버튼을 누르고있으면  ZoomIn(확대)을 하고싶다
        if (Input.GetButton("Fire2"))
        {
            targetZoomValue = zoomInValue;
           
            gunTargetPosision = zoomInPos.localPosition;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            // 그렇지 않고 떼면 ZoomOut(원래대로)을 하고싶다.
            targetZoomValue = zoomOutValue;
            gunTargetPosision = zoomOutPos.localPosition;
        }
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetZoomValue, Time.deltaTime * 20);

        gunObject.localPosition = Vector3.Lerp(gunObject.localPosition, gunTargetPosision, Time.deltaTime * 20);
    }

    void UpdateFire()
    {
        // 만약 마우스 왼쪽 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            // 메인카메라가 바라본곳에 총알자국을 남기고싶다.
            // 시선, 바라보다, 닿은곳의 정보
            // 메인카메라의 위치에서 메인카메라의 앞방향으로 시선을 만들고싶다.
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;
            // 바라보다.
            if (Physics.Raycast(ray, out hitInfo))
            {
                print(hitInfo.transform.name);
                // 총알자국을 부딪힌 곳에 남기고싶다.
                GameObject bImpact;
                bool isEnemy = hitInfo.collider.CompareTag("Enemy");

                //bImpact = Instantiate(isEnemy ? bImpactForEnemyFactory : bImpactFactory);

                if (isEnemy)
                {
                    bImpact = Instantiate(bImpactForEnemyFactory);
                }
                else
                {
                    bImpact = Instantiate(bImpactFactory);
                }

                bImpact.transform.position = hitInfo.point;
                bImpact.transform.forward = hitInfo.normal;

                // 만약 Enemy라면 
                if (isEnemy)
                {
                    Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                    // 너 총에 맞았어 라고 알려주고싶다.
                    // 데미지값을 알려주고싶다.
                    enemy.TryDamage(1);
                }
            }
        }
    }
}
