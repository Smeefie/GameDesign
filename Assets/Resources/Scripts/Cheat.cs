using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cheat : MonoBehaviour
{
    public bool Enabled = false;

    void Update()
    {
        if (enabled && Condition())
        {
            Debug.Log("The cheat " + GetName() + " has been pressed.");
            Action();
        }
    }
    protected abstract void Action();
    protected abstract bool Condition();
    protected abstract string GetName();
}
