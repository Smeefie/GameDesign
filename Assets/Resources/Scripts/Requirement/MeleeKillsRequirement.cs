using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Requirement
{
    [CreateAssetMenu(fileName = "Melee Kills", menuName = "Requirement/Melee Kills")]
    public class MeleeKillsRequirement : RequirementObject
    {
        public override float completionPercentage(runtimeStatistics stats)
        {
            var result = (stats.MeleeKills / requirements.Find(rq => rq.name == "MeleeKills").amount) * 100;
            if (result > 100) result = 100;
            return result;
        }

        public override bool isSatisfied(runtimeStatistics stats)
        {
            foreach (var requirement in satisfyBeforehand)
            {
                if (!requirement.isSatisfied(stats)) return false;
            }

            return stats.MeleeKills >= requirements.Find(rq => rq.name == "MeleeKills").amount;
        }
    }
}
