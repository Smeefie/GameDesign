using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Scripts.Menu.Unlockables;
using Assets.Resources.Scripts.Player.Abilities;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public Transform player;
    

    void Start()
    {
        var runtimeStats = player.GetComponent<StatisticManager>().runtimeStats;
        var abilityManager = player.GetComponent<AbilityManager>();
        List<AbilitySlot> abilitySlots = gameObject.GetComponentsInChildren<AbilitySlot>().ToList();

        foreach (var abilitySlot in abilitySlots)
        {
            if (abilitySlot.ability.unlockRequirement.isSatisfied(runtimeStats))
            {
                abilitySlot.Unlock();
            }

            abilitySlot.Equiped = abilityManager.isEquiped(abilitySlot.ability);
        }
    }
}
