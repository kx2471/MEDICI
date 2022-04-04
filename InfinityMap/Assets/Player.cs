using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� �¿�Ű�� ������ �¿�� �̵��ϰ�ʹ�.
public class Player : MonoBehaviour
{
    // ������
    Vector3 targetPosition;
    // ������ ���
    public Transform[] list;
    // ���� ����������� �ε���
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        targetPosition.x = list[index].position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� index�� 0���� ũ�� ���� Ű�� ������
        if (index > 0 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            index--;
        }
        // ���� index < list.Length - 1 �̰� ������ Ű�� ������
        if (index < list.Length - 1 && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            index++;
        }

        targetPosition.x = list[index].position.x;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
    }
}
