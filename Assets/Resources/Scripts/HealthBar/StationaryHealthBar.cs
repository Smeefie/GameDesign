using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class StationaryHealthBar : Healthbar
{
    public new BaseStats baseStats;
    public new Health health;
    [SerializeField] private float SmoothTime = 0.2f;
    [SerializeField] private float DelayTime = 0.1f;
    [NonSerialized] protected Text text;
    private bool isLerping = false;

    protected override BaseStats getBaseStats()
    {
        return baseStats;
    }

    protected override Health getHealth()
    {
        return health;
    }

    protected Text getHealthDisplayText()
    {
        return gameObject.GetComponentInChildren<Text>();
    }

    protected override Slider getSlider()
    {
        return GetComponent<Slider>();
    }

    private void UpdateDisplayText()
    {
        getHealthDisplayText().text = $"{_currentHealth}/{_maxHealth}";
    }

    protected override void SetSlider(float amount)
    {
        StartCoroutine(lerpHealthbar(amount));

        
        _currentHealth = amount;

        UpdateDisplayText();
    }

    IEnumerator lerpHealthbar(float amount)
    {
        //yield return new WaitUntil(WaitForLerp);
        var originalHpFloat = _currentHealth / _maxHealth;
        var targetHpFloat = amount / _maxHealth;
        float elapsedTime = 0; 
        
        isLerping = true;
        while ((int)slider.value != (int)amount)
        {
            slider.value = Mathf.Round(Mathf.Lerp(originalHpFloat, targetHpFloat, elapsedTime) * _maxHealth);
            elapsedTime += SmoothTime;
            yield return new WaitForSeconds(DelayTime);
        }
        isLerping = false;
    }

    private bool WaitForLerp()
    {
        return !isLerping;
    }
}
