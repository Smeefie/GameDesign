using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(BaseStats), typeof(Rigidbody2D))]
[RequireComponent(typeof(ModuleSwapper), typeof(PlayerRenderer), typeof(PlayerMovementController))]
[RequireComponent(typeof(AbilityManager))]
public abstract class PlayerClass : MonoBehaviour
{
    protected BaseStats stats;
    protected AbilityManager abilityManager;
    protected ModuleSwapper moduleSwapper;

    void Start()
    {
        stats = GetComponent<BaseStats>();
        abilityManager = GetComponent<AbilityManager>();
        moduleSwapper = GetComponent<ModuleSwapper>();

        SetBaseStats();
        SetAbilities();
        SetModules();
    }

    protected abstract void SetBaseStats();
    private void SetAbilities()
    {
        abilityManager.AddAbility(KeyCode.Q, abilityOne());
        abilityManager.AddAbility(KeyCode.E, abilityTwo());
        abilityManager.AddAbility(KeyCode.R, abilityThree());
        abilityManager.AddAbility(KeyCode.F, abilityFour());
    }
    protected abstract void SetModules();

    protected abstract Ability abilityOne();
    protected abstract Ability abilityTwo();
    protected abstract Ability abilityThree();
    protected abstract Ability abilityFour();


}
