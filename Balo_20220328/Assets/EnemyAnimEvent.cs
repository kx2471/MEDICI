using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
    public Enemy enemy;

    public void OnEnemyAttackHit()
    {
        // 공격 Hit가 되는 순간
        enemy.OnEnemyAttackHit();
    }

    public void OnEnemyAttackFinished()
    {
        // 공격 애니메이션이 종료되는 순간
        enemy.OnEnemyAttackFinished();
    }

    public void OnEnemyReactFinished()
    {
        // 리액션 애니메이션이 종료되는 순간
        enemy.OnEnemyReactFinished();
    }
    public void OnEnemyDeathFinished()
    {
        // 죽음 애니메이션이 종료되는 순간
        enemy.OnEnemyDeathFinished();
    }

}
