using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class HealthBarController : Healthbar
{
    public BaseStats baseStats;
    public Health health;

    protected override BaseStats getBaseStats()
    {
        return baseStats;
    }

    protected override Health getHealth()
    {
        return health;
    }

    protected override Text getHealthDisplayText()
    {
        return gameObject.GetComponentInChildren<Text>();
    }

    protected override Slider getSlider()
    {
        return GetComponent<Slider>();
    }
}
