using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// agent기능을 이용해서 목적지를 향해서 이동하고싶다. 
// 목표검색, 이동, 공격
public class Enemy : MonoBehaviour
{
    // 열거형
    enum State
    {
        Idle,
        Move,
        Attack,
        React,
        Death,
    }
    // 현재 상태
    State state;

    NavMeshAgent agent;
    GameObject target;
    public Animator anim;
    EnemyHP enemyHP;

    //총에 맞으면 0.1초동안 Mat_White재질로 바뀌고싶다.
    SkinnedMeshRenderer[] rendList;
    public Material Mat_White;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        agent = GetComponent<NavMeshAgent>();
        enemyHP = GetComponent<EnemyHP>();
        rendList = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            // 만약 현재 상태가 목표검색이라면 검색만 하고싶다.
            case State.Idle: UpdateSearch(); break;
            // 그렇지않고 상태가 이동이라면 이동만 하고싶다.
            case State.Move: UpdateMove(); break;
            // 그렇지않고 상태가 공격이라면 공격만 하고싶다.
            case State.Attack: UpdateAttack(); break;
        }
    }

    private void UpdateAttack()
    {
        // 만약 목적지와의 거리가 공격가능거리가 아니라면?
        // 이동상태로 전이하고싶다.
    }

    private void UpdateMove()
    {
        // agent에게 목적지를 계속 알려주고싶다.
        agent.destination = target.transform.position;
        // 만약 목적지와의 거리가 <= 공격가능거리라면?
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            // 공격상태로 전이하고싶다.
            state = State.Attack;
            anim.SetTrigger("Attack");
        }
    }

    private void UpdateSearch()
    {
        // 목적지를 찾고싶다. 
        target = GameObject.Find("Player");
        // 만약 목적지를 찾았으면
        if (target != null)
        {
            // 이동상태로 전이하고싶다.
            state = State.Move;
            anim.SetTrigger("Move");
        }
    }

    internal void OnEnemyAttackHit()
    {
        print("OnEnemyAttackHit");
        // 만약 공격가능거리라면 Hit를 하고싶다.
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            print("Hit!!!!");
            HitManager.instance.DoHitPlz();
            PlayerHP php = target.GetComponent<PlayerHP>();
            php.HP--;
            if(php.HP <= 0)
            {
                //게임오버
            }
        }
    }

    internal void OnEnemyAttackFinished()
    {
        print("OnEnemyAttackFinished");
        // 만약 공격가능거리가 아니라면
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > agent.stoppingDistance)
        {
            // 이동상태로 전이하고싶다.
            state = State.Move;
            anim.SetTrigger("Move");
        }
    }

    /// <summary>
    /// Player -> Enemy를 공격함.
    /// </summary>
    public void TryDamage(int damageValue)
    {
        // 만약 체력이 0이라면 함수를 바로 종료하고싶다.
        if(state == State.React || state == State.Death)
        {
            return;
        }
        
        
        if (enemyHP.HP <= 0)
        {
            return;
        }
        enemyHP.HP -= damageValue;
        agent.isStopped = true;
        if (enemyHP.HP <= 0)
        {
            // 죽음..
            state = State.Death;
            anim.SetTrigger("Death");
            //GetComponent<Collider>().enabled = false;
        }
        else
        {
            // 리액션
            state = State.React;
            anim.SetTrigger("React");
        }

        for (int i = 0; i < rendList.Length; i++)
        {
            StartCoroutine("IEWhite", i);
        }

    }

    IEnumerator IEWhite(int index)
    {
        SkinnedMeshRenderer rend = rendList[index];
        Material mat = rend.material;
        rend.material = Mat_White;
        yield return new WaitForSeconds(0.1f);
        rend.material = mat;
    }


    internal void OnEnemyReactFinished()
    {
        // 리액션 애니메이션이 종료되는 순간 이동상태로 전이하고싶다.
        state = State.Move;
        anim.SetTrigger("Move");
        agent.isStopped = false;
    }

    

    internal void OnEnemyDeathFinished()
    {
        // 죽음 애니메이션이 종료되는 순간 스스로 파괴되고싶다.
        Destroy(gameObject);
        //적이 파괴될 때 KillCount를 1 증가시키고 싶다.
        LevelManager.instance.KillCount++;
    }

}
