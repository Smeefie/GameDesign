using Assets.Resources.Scripts.Reward;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDeath : Death
{
    [SerializeField] private RewardObject reward;

    public override void DeathAction()
    {
        isDead = true;
    }

    internal void AwardKill(StatisticManager stats)
    {
        reward.Award(stats.runtimeStats);
        Destroy(gameObject);
    }
}
