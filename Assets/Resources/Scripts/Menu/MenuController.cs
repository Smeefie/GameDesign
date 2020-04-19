using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Menu.Unlockables;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public UnlockManager unlockManager;
    private bool isOpen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) openUnlockManager();
    }

    void openUnlockManager()
    {
        if (isOpen)
        {
            isOpen = false;
            Destroy(GetComponentInChildren<UnlockManager>().gameObject);
        }
        else
        {
            isOpen = true;
            Instantiate(unlockManager, this.transform);
        }
        
    }
}
