using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJE_PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 20;
    public float jumpAmount = 10;
    public bool isGrounded = false;
    public int jumpCount = 2;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = 0;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // Ground�� ������ isGrounded�� true
            jumpCount = 2; // Ground�� ������ ����Ƚ���� 2�� �ʱ�ȭ��
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
                    jumpCount--; // ������ ������ ���� Ƚ�� ����
                    anim.SetTrigger("JUMP");
                }
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("h", h);
        anim.SetFloat("v", v);

        dir = new Vector3(h, 0, v);


    }
    Vector3 dir;
    private void FixedUpdate()
    {
        /*
                // �Էµ� dir �� ī�޶��� ���� �������� �ٲ�
                dir =Camera.main.transform.TransformDirection(dir);
        */
        // �Էµ� dir �� ĳ������ ���� �������� �ٲ�
        dir = transform.TransformDirection(dir);
        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);

    
    }

}

