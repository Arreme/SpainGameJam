using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float forceX;
    public float forceY;
    public Rigidbody2D enemy;
    public DarknessChrono torch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            enemy = collision.gameObject.GetComponent<Rigidbody2D>();
            if (damageable != null) damageable.Damage(damage);
            if (enemy != null) enemy.AddForce(new Vector2((collision.transform.position.x - transform.position.x) * forceX, forceY));
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            DarknessChrono dkc = collision.gameObject.GetComponent<DarknessChrono>();
            dkc.enabled = true;
            if(torch != null && dkc != torch)
            {
                torch.enabled = false;
            }            
            dkc.Reset(true);

            torch = dkc;
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Spawner"))
        {
            GameObject.FindGameObjectWithTag("Pool").GetComponent<EnemyPooler>().deleteSpawnPoint(collision.gameObject);
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<Collider2D>().enabled = false;
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            collision.GetComponent<BossAI>().sendAttack();
            collision.GetComponent<BossAI>().tpRecievedDmg();
        }

    }
}
