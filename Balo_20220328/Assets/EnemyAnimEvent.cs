using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
    public Enemy enemy;

    public void OnEnemyAttackHit()
    {
        // ���� Hit�� �Ǵ� ����
        enemy.OnEnemyAttackHit();
    }

    public void OnEnemyAttackFinished()
    {
        // ���� �ִϸ��̼��� ����Ǵ� ����
        enemy.OnEnemyAttackFinished();
    }

    public void OnEnemyReactFinished()
    {
        // ���׼� �ִϸ��̼��� ����Ǵ� ����
        enemy.OnEnemyReactFinished();
    }
    public void OnEnemyDeathFinished()
    {
        // ���� �ִϸ��̼��� ����Ǵ� ����
        enemy.OnEnemyDeathFinished();
    }

}
