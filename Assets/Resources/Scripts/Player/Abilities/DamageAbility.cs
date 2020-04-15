using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Player.Abilities.Buffs;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities
{
    public class DamageAbility : Ability
    {
        public Health TestTarget; //Todo Implement hitbox later

        public int DamageDealt;
        public int Delay;
        public bool DamageOverTime;
        public int Interval = 1;
        public float ApplyEveryNSeconds;

        public override void PlayAbility()
        {
            var DoT = TestTarget.gameObject.AddComponent<DamageDebuff>();
            DoT.DamageDealt = DamageDealt;
            DoT.Delay = Delay;
            DoT.DamageOverTime = DamageOverTime;
            DoT.Interval = Interval;
            DoT.ApplyEveryNSeconds = ApplyEveryNSeconds;
        }
    }
}
