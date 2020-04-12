using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Healthbar : MonoBehaviour
{
    protected float _maxHealth;
    protected float _currentHealth;
    [NonSerialized] protected Slider slider;
    [NonSerialized] protected Health health;
    [NonSerialized] protected BaseStats baseStats;

    void Start()
    {
        slider = getSlider();
        health = getHealth();
        baseStats = getBaseStats();
        SetMaxHealth(baseStats.Health);
        SetSlider(health.CurrentHealth);
        health.OnChangeHealth += SetHealth;
    }


    public void SetMaxHealth(float amount)
    {
        _maxHealth = amount;
        _currentHealth = _maxHealth; //To have it have a value when first used
        slider.maxValue = amount;
    }

    public void SetHealth(float amount)
    {
        SetSlider(amount);
    }

    protected virtual void SetSlider(float amount)
    {
        slider.value = amount;
        _currentHealth = amount;
    }

    protected abstract Health getHealth();
    protected abstract BaseStats getBaseStats();
    protected abstract Slider getSlider();
}
