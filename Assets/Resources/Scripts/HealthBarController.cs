using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public BaseStats baseStats;

    void Start()
    {
        SetMaxHealth(baseStats.Health);
        Health.current.OnChangeHealth += SetHealth;
    }

    public void SetMaxHealth(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetHealth(float amount)
    {
        slider.value = amount;
        Debug.Log(amount);
    }
}
