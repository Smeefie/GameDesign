using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Player.Abilities;
using Assets.Resources.Scripts.Player.Abilities.Cost;
using UnityEngine;

public class DefaultClass : PlayerClass
{
    public Health target;


    protected override void SetBaseStats()
    {

    }

    protected override void SetModules()
    {

    }

    protected override Ability abilityOne()
    {
        DamageAbility ability = gameObject.AddComponent<DamageAbility>();
        ability.Name = "Headbutt";
        ability.Description = "Headbutt enemy, Deals melee damage.";
        ability.sharedCD = new List<string>() { "Melee" };
        ability.baseCooldown = 1;
        ability.cost = new NoCost();

        ability.DamageDealt = 40;
        ability.DamageOverTime = false;
        ability.Delay = 0;
        ability.TestTarget = target;


        return ability;
    }
    protected override Ability abilityTwo()
    {
        DamageAbility ability = gameObject.AddComponent<DamageAbility>();
        ability.Name = "Spit";
        ability.Description = "Spit at an enemy, Deals ranged damage.";
        ability.sharedCD = new List<string>() { "Ranged" };
        ability.baseCooldown = 0;
        ability.cost = new NoCost();

        ability.DamageDealt = 15;
        ability.DamageOverTime = false;
        ability.Delay = 0;
        ability.TestTarget = target;

        return ability;
    }

    protected override Ability abilityThree()
    {
        DebugLogText ability = gameObject.AddComponent<DebugLogText>();
        ability.Name = "AbilityThree";
        ability.Description = "PlaceholderThree";
        ability.sharedCD = new List<string>() { "Placeholder" };
        ability.baseCooldown = 2;
        ability.Text = ability.Name;
        ability.cost = new NoCost();

        return ability;
    }


    protected override Ability abilityFour()
    {
        DebugLogText ability = gameObject.AddComponent<DebugLogText>();
        ability.Name = "AbilityFour";
        ability.Description = "PlaceholderFour";
        ability.sharedCD = new List<string>() { "Placeholder" };
        ability.baseCooldown = 2;
        ability.Text = ability.Name;
        ability.cost = new HealthCost(25);

        return ability;
    }
}
