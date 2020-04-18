using Assets.Resources.Scripts.Reward;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour
{
    private Health health;
    public bool isDead = false;
    [SerializeField] private RewardObject reward;

    void Start()
    {
        health = gameObject.GetComponent<Health>();

        health.OnHealthZero += DeathAction;
    }

    void DeathAction()
    { 
        isDead = true;
        //TODO: die here;
    }

    internal void AwardKill(StatisticManager stats)
    {
        reward.Award(stats.runtimeStats);
        Destroy(gameObject);
    }
}
