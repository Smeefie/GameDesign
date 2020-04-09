using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Teleport : Cheat
{
    public Transform Player;

    protected override void Action()
    {
       Player.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected override bool Condition()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    protected override string GetName()
    {
        return "Teleport";
    }
}
