using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_CameraController : MonoBehaviour
{
    public GameObject player; // �ٶ� �÷��̾� ������Ʈ�Դϴ�.
    public float xmove = 0;  // X�� ���� �̵���
    public float ymove = 0;  // Y�� ���� �̵���
    public float distance = 3;

    float rx;
    float ry;
    public float rotSpeed = 5;

    public float SmoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    private int toggleView = 3; // 1=1��Ī, 3=3��Ī


    public Transform target;
    public Transform lookTarget;

    private void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X"); // ���콺�� �¿� �̵����� xmove �� �����մϴ�.
            ymove -= Input.GetAxis("Mouse Y"); // ���콺�� ���� �̵����� ymove �� �����մϴ�.
           
        }

        if (Input.GetMouseButtonDown(2))
            toggleView = 4 - toggleView;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(ymove, xmove, 0); // �̵����� ���� ī�޶��� �ٶ󺸴� ������ �����մϴ�.

        //  ���콺 ��Ŭ�� �߿��� ī�޶� ���� ����
        if (toggleView == 1)
        {
            Vector3 reverseDistance = new Vector3(0.0f, 0.4f, 0.2f); // ī�޶� �ٶ󺸴� �չ����� Z ���Դϴ�. �̵����� ���� Z ������� ���͸� ���մϴ�.
            transform.position = player.transform.position + transform.rotation * reverseDistance; // �÷��̾��� ��ġ���� ī�޶� �ٶ󺸴� ���⿡ ���Ͱ��� ������ ��� ��ǥ�� �����մϴ�.
            // dir ���ؿ��� �� dir �� y ���� ���� �մϴ�.

            Vector3 chardir = transform.forward;
            chardir.y = 0;

            player.transform.forward = chardir;

        }
        else if (toggleView == 3)
        {
            //Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance); // ī�޶� �ٶ󺸴� �չ����� Z ���Դϴ�. �̵����� ���� Z ������� ���͸� ���մϴ�.
            //transform.position = Vector3.SmoothDamp(
            //    transform.position,
            //    player.transform.position - transform.rotation * reverseDistance,
            //    ref velocity,
            //    SmoothTime);

            Vector3 targetPosition = target.transform.position;
            //lookTarget���� target������ �ٶ󺸰� �ε������� �ִٸ�
            Ray ray = new Ray(lookTarget.position, targetPosition - lookTarget.position);

            RaycastHit hitinfo;

            if (Physics.Raycast(ray, out hitinfo))
            {

                //�� ��ġ�� targetPosition�� �ǰ� �ϰ� �ʹ�.
                targetPosition = hitinfo.point;
            }

            transform.position = Vector3.Lerp(transform.position,
                targetPosition, Time.deltaTime * 10);
            


            Vector3 chardir = transform.forward;
            chardir.y = 0;

            player.transform.forward = chardir;
        }


    }
}