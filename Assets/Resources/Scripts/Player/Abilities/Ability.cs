using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Scripts.Player.Abilities;
using Assets.Resources.Scripts.Player.Abilities.CostClass;
using Assets.Resources.Scripts.Requirement;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public RequirementObject unlockRequirement;
    public string Name;
    public string Description;
    public Cost cost;
    public List<string> sharedCD;
    public int baseCooldown;

    //Todo: add animation (to play from caster)

    public abstract void PlayAbility(Transform user);
}
