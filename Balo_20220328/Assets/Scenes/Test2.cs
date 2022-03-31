using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//delegate : 대리자 : 함수를 담는 변수
public class Test2 : MonoBehaviour
{


    public TestCube cube;

    // Start is called before the first frame update
    void Start()
    {
        //큐브에게 이동을 요청하고싶은데 오른쪽으로 이동이 끝나면 위로 이동하고
        //위로이동이 끝나면 왼쪽으로, 그다음은 아래쪽으로 이동하게 하고 싶다

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
