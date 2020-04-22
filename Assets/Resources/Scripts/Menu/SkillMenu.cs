using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Scripts.Menu.Unlockables;
using Assets.Resources.Scripts.Player.Abilities;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    [NonSerialized ]public Transform player;
    

    void Start()
    {
        var stats = player.GetComponent<StatisticManager>();
        var abilityManager = player.GetComponent<AbilityManager>();
        List<AbilitySlot> abilitySlots = gameObject.GetComponentsInChildren<AbilitySlot>().ToList();

        foreach (var abilitySlot in abilitySlots)
        {
            if (abilitySlot.ability.unlockRequirement.isSatisfied(stats))
            {
                abilitySlot.Unlock();
            }

            abilitySlot.Equiped = abilityManager.isEquiped(abilitySlot.ability);
        }
    }
}
