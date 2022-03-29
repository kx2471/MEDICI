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

        //태어날때 이동 방향을 정하고싶다
        // 30%확률로 플레이어 방향, 나머지 확률로 아래방향으로 하고 싶다.
        int rValue = Random.Range(0, 10);
        if (rValue < 3)
        {
            //30%확률로 플레이어 방향,
            //플레이어의 위치를 알고싶다.
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;
            dir.Normalize();



        }

    }
        // Update is called once per frame
        void Update()
        {
            //살아가면서 그 정한 방향으로 이동하고싶다.
            transform.position += dir * speed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {

            //너죽고 나죽자
            Destroy(collision.gameObject);
            //나죽자
            Destroy(gameObject);

        }


    }
