using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string Name;
    public string Description;
    
    public List<string> sharedCD;
    public int baseCooldown;

    public abstract void PlayAbility();
    public abstract bool Cost();
}
