using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogText : Ability
{
    public string Text;

    public override bool Cost()
    {
        return true;
    }

    public override void PlayAbility()
    {
        Debug.Log(Text);
    }
}
