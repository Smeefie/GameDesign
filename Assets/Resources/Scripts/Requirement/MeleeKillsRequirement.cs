using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Player.Abilities;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Requirement
{
    [CreateAssetMenu(fileName = "Melee Kills", menuName = "Requirement/Melee Kills")]
    public class MeleeKillsRequirement : RequirementObject
    {
        public override float completionPercentage(StatisticManager stats)
        {
            int meleekills = 0;
            foreach (var abilitydata in stats.abilityData)
            {
                var DamageAbility = (DamageAbility) abilitydata.ability;
                if (DamageAbility.category == DamageCategory.melee) meleekills += abilitydata.killed;
            }

            var result = (meleekills / requirements.Find(rq => rq.name == "MeleeKills").amount) * 100;
            if (result > 100) result = 100;
            return result;
        }

        public override bool isSatisfied(StatisticManager stats)
        {
            foreach (var requirement in satisfyBeforehand)
            {
                if (!requirement.isSatisfied(stats)) return false;
            }

            int meleekills = 0;
            foreach (var abilitydata in stats.abilityData)
            {
                var DamageAbility = (DamageAbility)abilitydata.ability;
                if (DamageAbility.category == DamageCategory.melee) meleekills += abilitydata.killed;
            }

            return meleekills >= requirements.Find(rq => rq.name == "MeleeKills").amount;
        }
    }
}
