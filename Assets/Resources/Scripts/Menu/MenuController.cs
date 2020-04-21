using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Menu.Unlockables;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public UnlockManager unlockManager;
    public SkillMenu skillMenu;


    public Transform Player;

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
            var item = Instantiate(unlockManager, this.transform);
            item.player = Player;
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
            var item = Instantiate(skillMenu, this.transform);
            item.player = Player;
        }
    }
}
