using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed = 5;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {

        //�¾�� �̵� ������ ���ϰ�ʹ�
        // 30%Ȯ���� �÷��̾� ����, ������ Ȯ���� �Ʒ��������� �ϰ� �ʹ�.
        int rValue = Random.Range(0, 10);
        if (rValue < 3)
        {
            //30%Ȯ���� �÷��̾� ����,
            //�÷��̾��� ��ġ�� �˰�ʹ�.
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;
            dir.Normalize();



        }

    }
        // Update is called once per frame
        void Update()
        {
            //��ư��鼭 �� ���� �������� �̵��ϰ�ʹ�.
            transform.position += dir * speed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {

            //���װ� ������
            Destroy(collision.gameObject);
            //������
            Destroy(gameObject);

        }


    }
