using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable
{
    new private void Awake()
    {
        base.Awake();
    }

    public override void Damage(float amount)
    {
        base.Damage(amount);
    }

    public override void Kill()
    {
        gameObject.SetActive(false);
    }
}
