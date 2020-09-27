using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    EnemyPooler enemyPooler;

    private void Start()
    {
        enemyPooler = EnemyPooler.instance;
        InvokeRepeating("spawnMob", 0, 2f);
    }


    private void spawnMob()
    {
        int alive = 0;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            alive++;
        }

        if (GameObject.FindGameObjectWithTag("Spawner").GetComponentInParent<EnemyPooler>().getSize() >= alive)
        {
            enemyPooler.SpawnFromPool("Enemy");
        }
    }
}
