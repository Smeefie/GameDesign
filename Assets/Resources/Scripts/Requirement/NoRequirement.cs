using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Requirement;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

[CreateAssetMenu(fileName = "None", menuName = "Requirement/None")]
public class NoRequirement : RequirementObject
{
    public override float completionPercentage(StatisticManager stats)
    {
        return 100;
    }

    public override bool isSatisfied(StatisticManager stats)
    {
        return true;
    }
}
