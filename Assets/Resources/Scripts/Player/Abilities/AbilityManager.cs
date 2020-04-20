using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Scripts.Player.Abilities;
using MyBox;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [Serializable]
    private struct AbilitySlots { public KeyCode keycode; public Ability ability; }

    [SerializeField] private List<AbilitySlots> abilities;
    [SerializeField] private float internalCDDuration = 2f;
    private bool onInternalCD = false;

    void Update()
    {
        if (!onInternalCD)
        {
            if (CheckForAbility())
            {
                var keycode = GetKeyCodePressed();
                var ability = GetAbilityByKeycode(keycode);
                if (IsOffCooldown(ability))
                {
                    if (ability.cost.Pay(gameObject))
                    {
                        logCast(ability);
                        PlayAbility(ability);
                        StartCoroutine(InternalCD());
                    }
                }
            }
        }
    }

    IEnumerator InternalCD()
    {
        onInternalCD = true;
        yield return new WaitForSeconds(internalCDDuration);
        onInternalCD = false;
    }

    public void AddAbility(KeyCode keyCode, Ability ability)
    {

        OverrideKeycode(keyCode);

        var abilitySlot = new AbilitySlots()
        {
            ability = ability,
            keycode = keyCode
        };
        abilities.Add(abilitySlot);
    }

    void OverrideKeycode(KeyCode keycode)
    {
        if (abilities.Exists(i => i.keycode == keycode))
        {
            abilities.Remove(abilities.Single(i => i.keycode == keycode));
        }
    }

    public KeyCode GetKeyCodePressed()
    {
        foreach (var abilitySlot in abilities)
        {
            if (Input.GetKeyDown(abilitySlot.keycode))
            {
                return abilitySlot.keycode;
            }
        }
        throw new Exception("No keycode was found");
    }

    public bool CheckForAbility()
    {
        foreach (var abilitySlot in abilities)
        {
            if (Input.GetKeyDown(abilitySlot.keycode))
            {
                return true;
            }
        }

        return false;
    }

    void PlayAbility(Ability ability)
    {
        var cooldown = gameObject.AddComponent<Cooldown>();
        cooldown.ability = ability;
        ability.PlayAbility(gameObject.transform);
    }

    bool IsOffCooldown(Ability ability)
    {
        if (!gameObject.HasComponent<Cooldown>()) return true;

        var CDs = gameObject.GetComponents<Cooldown>();

        var result = (CDs.Count(cd => cd.ability.sharedCD.Any(x => ability.sharedCD.Contains(x))) == 0);
        return result;
    }

    Ability GetAbilityByKeycode(KeyCode keycode)
    {
        return abilities.Single(i => i.keycode == keycode).ability;
    }

    internal int getAbilityCount()
    {
        return abilities.Count;
    }

    protected void logCast(Ability abil)
    {
        var stats = gameObject.GetComponent<StatisticManager>();
        if (!stats.abilityData.Exists(i => i.ability.Name == abil.Name)) stats.abilityData.Add(new AbilityDataModel() { ability = abil });
        stats.abilityData.Find(i => i.ability.Name == abil.Name).used++;
    }

    internal void unequipAbility(Ability ability)
    {
        abilities.Remove(abilities.Single(i => i.ability.Name == ability.Name));
    }

    public bool isEquiped(Ability ability)
    {
        return abilities.Exists(i=>i.ability == ability);
    }

    internal IEnumerable<KeyCode> getKeycodesInUse()
    {
        foreach (var abilityslot in abilities)
        {
            yield return abilityslot.keycode;
        }
    }
}
