using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Reward
{
    public abstract class RewardObject : ScriptableObject
    {
        public abstract void Award(runtimeStatistics stats);
    }
}
