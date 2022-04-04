using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 입력에따라 상하좌우로 이동하고싶다. : 기획
// [속성]
// - 속력
public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 이동공식 P = P0 + vt 
        // v : velocity : 방향과 속력을 가진 물리량

        // 1. 사용자의 입력에따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. 상하좌우로 방향을 만들고
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        // 문제발생!! dir의 크기가 1이 아닌경우가 있다. 크기를 1로 만들어주고싶다.
        dir.Normalize();
        // 3. 그 뱡항으로 이동하고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }

}
