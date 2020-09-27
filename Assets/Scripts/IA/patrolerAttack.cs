using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolerAttack : MonoBehaviour
{
    [SerializeField]
    float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
           collision.gameObject.GetComponent<PlayerHealthSystem>().takeDamage(damage);
            }
        }

    }

