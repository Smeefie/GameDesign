using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Player.Abilities.Cost;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string Name;
    public string Description;
    public Cost cost;
    public List<string> sharedCD;
    public int baseCooldown;

    public abstract void PlayAbility();
}
