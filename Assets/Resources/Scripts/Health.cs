using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public BaseStats baseStats;
    private float CurrentHealth;

    void Start()
    {
        baseStats = GetComponent<BaseStats>();
        ChangeHealth(baseStats.Health);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeHealth(-10);
        }
    }

    public event Action<float> OnChangeHealth;
    public void ChangeHealth(float amount)
    {
        CurrentHealth += amount;

        OnChangeHealth?.Invoke(CurrentHealth);
    }
}
