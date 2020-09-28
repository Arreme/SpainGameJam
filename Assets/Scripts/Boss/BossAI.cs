using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private BossHealth health;
    private IBossAtack attack;
    [SerializeField]
    private float minAttackTime;
    [SerializeField]
    private float maxAttackTime;
    private bool timeDecided;
    private float time;

    void Awake()
    {
        health = GetComponent<BossHealth>();
        timeDecided = false;
        attack = new PrimeraFase();
    }

     
    void Update()
    {
        if (!timeDecided)
        {
            time = Random.Range(minAttackTime,maxAttackTime);
            timeDecided = true;
        }
        bossState(health.CurrentHealth);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            timeDecided = false;
            attack.mainAttack();
        }
    }

    private void bossState(float health)
    {
        if (health <= 75 && health > 50)
        {
            changeAttack("SegonaFase");
        }
        else if (health == 50)
        {
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFollows>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
            GameObject.FindGameObjectWithTag("darknessEnlarger").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
        }  
        else if (health>= 25 && health<50)
        {
            changeAttack("TerceraFase");
        }
        else if (health < 25)
        {
            changeAttack("LastFase");
        }
    }

    public void changeAttack(string attack)
    {
        if (!attack.Equals(this.attack.ToString()))
        {
            this.attack = AttackInit.generateAttack(attack);
            Debug.Log("Changed to" + this.attack);
        }
       
    }
}
