using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnemyHealth : Damageable
{
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

    public override void Damage(float amount)
    {
        base.Damage(amount);
    }

    private void SliderUpdate()
    {
        slider.value = Mathf.Lerp(slider.value, currentHealth, sliderSmooth);
    }

    public override void Kill()
    {
        base.Kill();
    }
}
