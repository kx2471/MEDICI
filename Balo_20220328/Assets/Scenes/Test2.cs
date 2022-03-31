using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//delegate : �븮�� : �Լ��� ��� ����
public class Test2 : MonoBehaviour
{


    public TestCube cube;

    // Start is called before the first frame update
    void Start()
    {
        //ť�꿡�� �̵��� ��û�ϰ������ ���������� �̵��� ������ ���� �̵��ϰ�
        //�����̵��� ������ ��������, �״����� �Ʒ������� �̵��ϰ� �ϰ� �ʹ�

        cube.Move(Vector3.right, OnMoveRightComplete);
    }

    void OnMoveRightComplete()
    {
        cube.Move(Vector3.up, OnMoveUpComplete);
    }
    void OnMoveUpComplete()
    {
        cube.Move(Vector3.left, OnMoveLeftComplete);
    }
    void OnMoveLeftComplete()
    {
        cube.Move(Vector3.down, OnMoveDownComplete);
    }
    void OnMoveDownComplete()
    {
        cube.Move(Vector3.right, OnMoveRightComplete);
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
