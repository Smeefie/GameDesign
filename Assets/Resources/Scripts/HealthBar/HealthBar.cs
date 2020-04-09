using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Text))] Write custom to do this for child-components
public abstract class Healthbar : MonoBehaviour
{
    protected float _maxHealth;
   
    void Start()
    {
        SetMaxHealth(getBaseStats().Health);
        var health = getHealth();
        SetSlider(health.CurrentHealth);
        UpdateDisplayText();
        health.OnChangeHealth += SetHealth;
    }


    public void SetMaxHealth(float amount)
    {
        _maxHealth = amount;
        getSlider().maxValue = amount;
    }

    public void SetHealth(float amount)
    {
        SetSlider(amount);
        UpdateDisplayText();
    }

    protected void SetSlider(float amount)
    {
        getSlider().value = amount;
    }

    protected void UpdateDisplayText()
    {
        getHealthDisplayText().text = $"{getHealth().CurrentHealth}/{_maxHealth}";
    }

    protected abstract Health getHealth();
    protected abstract BaseStats getBaseStats();
    protected abstract Slider getSlider();
    protected abstract Text getHealthDisplayText();
}
