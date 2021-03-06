﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceHealth : Cheat
{
    [SerializeField] private Health health;
    [SerializeField] private KeyCode KeyCode;
    [SerializeField] private float amount;
    protected override void Action()
    {
        health.ReduceHealth(amount);
    }

    protected override bool Condition()
    {
        return Input.GetKeyDown(KeyCode);
    }

    protected override string GetName()
    {
        return "Reduce health";
    }
}
