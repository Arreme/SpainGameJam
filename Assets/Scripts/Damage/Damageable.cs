using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;

    protected void Awake()
    {
        currentHealth = maxHealth;
        
    }

    public virtual void Damage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Kill();
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }

    public float Health
    {
        get
        {
            return currentHealth;
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
}
