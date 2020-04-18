using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Statistics
{
    [CreateAssetMenu(fileName = "Runtime Statistics", menuName = "Player/Runtime Statistics")]
    public class runtimeStatistics : ScriptableObject
    {
        public int CrabsKilled { get; set; } = 0;

        public void Clear()
        {
            CrabsKilled = 0;
        }
    }
}
