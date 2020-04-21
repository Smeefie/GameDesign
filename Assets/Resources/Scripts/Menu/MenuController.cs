using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Menu.Unlockables;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public UnlockManager unlockManager;
    public SkillMenu skillMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) openUnlockManager();
        if(Input.GetKeyDown(KeyCode.L)) openSkillMenu();
    }

    void openUnlockManager()
    {
        if (GetComponentInChildren<UnlockManager>() != null)
        {
            Destroy(GetComponentInChildren<UnlockManager>().gameObject);
        }
        else
        {
            Instantiate(unlockManager, this.transform);
        }
    }

    void openSkillMenu()
    {
        if (GetComponentInChildren<SkillMenu>() != null)
        {
            Destroy(GetComponentInChildren<SkillMenu>().gameObject);
        }
        else
        {
            Instantiate(skillMenu, this.transform);
        }
    }
}
