using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Teleport : Cheat
{
    public Transform Player;
    public KeyCode KeyCode;

    protected override void Action()
    {
       Player.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected override bool Condition()
    {
        return Input.GetKeyDown(KeyCode);
    }

    protected override string GetName()
    {
        return "Teleport";
    }
}
