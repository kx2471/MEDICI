using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� GŰ�� ������ ��ź���忡�� ��ź�� ���� �� ��ġ�� ��ġ�ϰ�ʹ�.
// ��ź�� �չ����� ���� �������� �ϴ� ����(�������� 45��)���� ȸ����Ű��ʹ�.
public class PlayerThrow : MonoBehaviour
{
    public GameObject grenadeFactory;
    public Transform grenadeThrowPosition;

    void Update()
    {
        // 1. ���� ����ڰ� GŰ�� ������
        if (Input.GetKeyDown(KeyCode.G))
        {
            // 2. ��ź���忡�� ��ź�� ����
            GameObject grenade = Instantiate(grenadeFactory);
            // 3. grenadeThrowPosition�� ��ġ�ϰ�ʹ�.
            grenade.transform.position = grenadeThrowPosition.position;
            // 4. ��ź�� �չ����� ���� �������� �ϴ� ����(�������� 50��)���� ȸ����Ű��ʹ�.

            //Quaternion q = grenadeThrowPosition.rotation * Quaternion.Euler(-50, 0, 0);
            //grenade.transform.rotation = q;
            grenade.transform.forward = grenadeThrowPosition.forward;


           

        }
    }
}
