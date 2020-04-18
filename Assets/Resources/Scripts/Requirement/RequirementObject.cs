using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Requirement
{
    public abstract class RequirementObject : ScriptableObject
    {
        [Serializable]
        public class Requirement
        {
            public string name; // Of enum doen? 
            public string description;
            public int amount;
        }

        public List<Requirement> requirements;
        public List<RequirementObject> satisfyBeforehand;
        public abstract bool isSatisfied(runtimeStatistics stats);

    }
}
