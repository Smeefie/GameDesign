using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : Cheat
{
    [SerializeField] private Health health;
    [SerializeField] private KeyCode KeyCode;
    [SerializeField] private float amount;
    protected override void Action()
    {
        health.IncreaseHealth(amount);
    }

    protected override bool Condition()
    {
        return Input.GetKeyDown(KeyCode);
    }

    protected override string GetName()
    {
        return "Increase health";
    }
}
