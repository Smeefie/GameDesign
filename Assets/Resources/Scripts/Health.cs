using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BaseStats))]
public class Health : MonoBehaviour
{
    [HideInInspector] private float _maxHealth;
    public float CurrentHealth;

    [SerializeField] private bool Immortal = false;

    void Start()
    {
        _maxHealth = GetComponent<BaseStats>().Health;
    }

    public event Action<float> OnChangeHealth;
    public void ReduceHealth(float amount)
    {
        if (Immortal) return;
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            //Todo death here
        }

        OnChangeHealth?.Invoke(CurrentHealth);
    }

    public void IncreaseHealth(float amount)
    {
        CurrentHealth += amount;

        if (CurrentHealth > _maxHealth) CurrentHealth = _maxHealth;

        OnChangeHealth?.Invoke(CurrentHealth);
    }
}
