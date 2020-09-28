using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField]
    BossAI boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boss.active = true;
    }
}
