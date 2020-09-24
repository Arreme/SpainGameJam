using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    EnemyPooler enemyPooler;

    private void Start()
    {
        enemyPooler = EnemyPooler.instance;
    }

    private void FixedUpdate()
    {       
        enemyPooler.SpawnFromPool("Enemy");
    }
}
