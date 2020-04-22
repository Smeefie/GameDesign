﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Requirement
{
    [CreateAssetMenu(fileName = "Kill crabs", menuName = "Requirement/Kill Crabs")]
    public class KillCrabsRequirement : RequirementObject
    {
        public override float completionPercentage(runtimeStatistics stats)
        {
            var result = (stats.CrabsKilled / requirements.Find(rq => rq.name == "CrabsKilled").amount) * 100;
            if (result > 100) result = 100;
            return result;
        }

        public override bool isSatisfied(runtimeStatistics stats)
        {
            foreach (var requirement in  satisfyBeforehand)
            {
                if (!requirement.isSatisfied(stats)) return false;
            }

            return stats.CrabsKilled >= requirements.Find(rq => rq.name == "KillCrabs").amount;
        }
    }
}