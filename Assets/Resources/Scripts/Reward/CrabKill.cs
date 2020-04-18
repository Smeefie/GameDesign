using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Reward
{
    [CreateAssetMenu(fileName = "CrabKill", menuName = "Rewards/CrabKill")]
    public class CrabKill : RewardObject
    {
        public override void Award(runtimeStatistics stats)
        {
            stats.CrabsKilled++;
        }
    }
}
