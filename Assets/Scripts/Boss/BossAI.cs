using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BossAI : MonoBehaviour
{
    private BossHealth health;
    private IBossAtack attack;
    [SerializeField]
    private float minAttackTime;
    [SerializeField]
    private float maxAttackTime;
    [SerializeField]
    Transform tpPosition;
    private bool timeDecided;
    private float time;
    public bool actived;

    void Awake()
    {
        health = GetComponent<BossHealth>();
        timeDecided = false;
        attack = new PrimeraFase();
        actived = false;
    }

     
    void Update()
    {
        if (actived)
        {
            if (!timeDecided)
            {
                time = Random.Range(minAttackTime, maxAttackTime);
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
            transform.position = tpPosition.position;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFollows>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
            GameObject.FindGameObjectWithTag("darknessEnlarger").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
        }  
        else if (health>= 25 && health<50)
        {
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFollows>().enabled = false;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFades>().InvokeRepeating("fadeOut", 0, 0.1f);
            GameObject.FindGameObjectWithTag("darknessEnlarger").GetComponent<DarknessFades>().InvokeRepeating("fadeOut", 0, 0.1f);
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
