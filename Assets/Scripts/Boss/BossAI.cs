using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnPoints;
    private int idxSP;

    private BossHealth health;
    private IBossAtack attack;
    [SerializeField]
    private float minAttackTime;
    [SerializeField]
    private float maxAttackTime;
    [SerializeField]
    Transform tpPosition;
    [SerializeField]
    float smashesNeeded;
    [SerializeField]
    float smashTimer;
    private bool timeDecided;
    private float time;
    private float smashes;
    public bool active;

    [SerializeField]
    List<Animation> anims;

    void Awake()
    {
        health = GetComponent<BossHealth>();
        timeDecided = false;
        attack = new PrimeraFase(anims);
        active = false;
    }

     
    void Update()
    {
        if (active)
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
            if (health.CurrentHealth > 50)
            {
                tpRecievedDmg();
            }
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
            smashTheButton();
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

    public void smashTheButton()
    {
        bool dead = false;
        while (!dead)
        {
            float timer = smashTimer;
            smashes = 0;
            while (timer > 0)
            {
                timer -= 1 * Time.deltaTime;
                if (smashes >= smashesNeeded)
                {
                    health.Kill();
                    dead = true;
                }
            }
        }        
    }

    public void sendAttack()
    {
        smashes++;
    }

    public void tpRecievedDmg()
    {
        idxSP = Random.Range(0, spawnPoints.Length);
        transform.position = new Vector3(spawnPoints[idxSP].transform.position.x, spawnPoints[idxSP].transform.position.y, 10);
    }
}
