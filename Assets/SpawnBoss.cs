using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField]
    BossAI boss;
    [SerializeField]
    Canvas slid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        slid.enabled = true;
        boss.active = true;
    }
}
