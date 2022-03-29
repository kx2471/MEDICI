using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 입력에따라 앞뒤좌우로 이동하고싶다.
// 점프를 뛰고싶다~~
// 뛰는힘, 중력, y속도
public class PlayerMove : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public float jumpPower = 10;
    public float gravity = -9.81f;
    float yVelocity;
    // 다중 점프를 뛰고싶다.
    int jumpCount;
    public int maxJumpCount = 2;
    void Update()
    {
        if (cc.isGrounded)
        {
            // 땅에 서 있다면 점프 횟수를 0으로 초기화 하고싶다.
            jumpCount = 0;
        }
        else
        {
            // 만약 공중이라면
            // 1. y속도는 중력을 계속 받아야한다. -9.81m/s
            yVelocity += gravity * Time.deltaTime;
        }

        // 2. 만약 점프횟수가 최대점프횟수보다 작고 점프 버튼을 누르면 y속도에 jumpPower로 대입하고싶다.
        if (jumpCount < maxJumpCount && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            jumpCount++;
        }



        // 1. 사용자의 입력에따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. 앞뒤좌우로 방향을 만들고
        Vector3 dir = new Vector3(h, 0, v);


        // 방향(dir)을 카메라를 기준으로 변경하고싶다.
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        dir.Normalize();
        Vector3 velocity = dir * speed;
        // 3. 이동방향의 y속성에 y속도를 대입하고싶다.
        velocity.y = yVelocity;

        // 3. 그 방향으로 이동하고싶다.
        cc.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 from = transform.position;
        Vector3 to = transform.position + Vector3.up * yVelocity;
        Gizmos.DrawLine(from, to);
    }
}
