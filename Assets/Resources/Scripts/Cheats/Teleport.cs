using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Teleport : Cheat
{
    [SerializeField] private Transform Player;
    [SerializeField] private KeyCode KeyCode;

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
