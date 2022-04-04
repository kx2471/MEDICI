using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 태어날때 이동방향을 정하고싶다. 
// 30% 확률로 플레이어 방향, 나머지 확률로 아래방향으로 정하고싶다.
// 살아가면서 그 정한 방향으로 이동하고싶다.
public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        // 태어날때 이동방향을 정하고싶다. 
        int rValue = Random.Range(0, 10);
        if (rValue < 3)
        {
            // 30% 확률로 플레이어 방향,
            // 플레이어의 위치를 알고싶다.
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            // 나머지 확률로 아래방향으로 정하고싶다.
            dir = Vector3.down;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // 살아가면서 그 정한 방향으로 이동하고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }

    // 누군가와 부딪힌 순간 호출되는 함수다.
    // 누군가와 부딪히면 폭발공장에서 폭발을 만들어서 내 위치에 가져다 놓고싶다.
    public GameObject explosionFactory;
    private void OnCollisionEnter(Collision collision)
    {
        // 폭발공장에서 폭발을 만들어서 내 위치에 가져다 놓고싶다.
        GameObject exp = Instantiate(explosionFactory);
        exp.transform.position = transform.position;
        // 폭발 애니메이션을 재생하고싶다.
        ParticleSystem ps = exp.GetComponent<ParticleSystem>();
        ps.Play();
        // 3초후에 파괴하고싶다.
        Destroy(exp, 3);

        // Enemy와 누군가가 부딪힌 상황이다.
        // Player인지 Bullet인지 구분하고싶다. 
        // 만약 상대방의 이름에 "Bullet"문자열이 포함되어 있다면
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // ScoreManager 컴포넌트의 점수를 1점 증가시키고 싶다.
            ScoreManager.instance.SCORE++;
            // 너죽고 
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("Player"))
        {
            // 플레이어의 체력을 1 감소시키고싶다.
            PlayerHP php = collision.gameObject.GetComponent<PlayerHP>();
            php.HP--;
            // 만약 플레이어의 체력이 0이하라면
            if (php.HP <= 0)
            {
                // 너죽고를 하고싶다.
                Destroy(collision.gameObject);

                // 플레이어와 부딪혔다
                // 플레이어가 파괴될때 GameOverUI를 활성화 하고싶다.
                GameManager.instance.GameOverUI.SetActive(true);

            }
        }
        // 나죽자
        Destroy(gameObject);
    }
}
