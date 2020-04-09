using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public BaseStats baseStats;
    public Health health;

    void Start()
    {
        SetMaxHealth(baseStats.Health);
        health.OnChangeHealth += SetHealth;
    }

    public void SetMaxHealth(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetHealth(float amount)
    {
        slider.value = amount;
    }
}
