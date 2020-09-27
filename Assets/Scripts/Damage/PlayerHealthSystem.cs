using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealthSystem : Damageable
{
    public Transform respawn;
    public Slider slider;
    public float sliderSmooth = 0.15f;

    new private void Awake()
    {
        base.Awake();
        slider.maxValue = maxHealth;
        slider.value = slider.maxValue;
    }

    private void FixedUpdate()
    {
        SliderUpdate();
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public override void Kill()
    {
        Respawn();
    }

    public void Respawn()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        currentHealth = maxHealth;

        GameObject[] playerEnables = GameObject.FindGameObjectsWithTag("PlayerEnable");
        foreach (GameObject playerEnable in playerEnables)
        {
            playerEnable.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void setRespawn(Transform respawn)
    {
        this.respawn = respawn;
    }

    private void SliderUpdate()
    {
        slider.value = Mathf.Lerp(slider.value, currentHealth, sliderSmooth);
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
