using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Resources.Scripts.Player.Abilities.Buffs.ScriptableObjects;

namespace Assets.Resources.Scripts.Player.Abilities.Buffs
{
    [Serializable]
    public class DamageDebuff : Debuff
    {
        private Ability origin;
        public DamageNumbers damage;
        public DamageCategory category;
        public DamageType damagetype;

        private int appliedTimes = 0;

        protected override IEnumerator Effect()
        {
            var stats = Owner.GetComponent<StatisticManager>();
            yield return new WaitForSeconds(damage.Delay);

            if (!damage.DamageOverTime) damage.Interval = 1;

            while (appliedTimes < damage.Interval)
            {
                gameObject.GetComponent<Health>().ReduceHealth(damage.DamageDealt);
                yield return new WaitForSeconds(damage.ApplyEveryNSeconds);
                appliedTimes++;
            }

            var death = GetComponent<Death>();
            if (death.isDead)
            {
                logKill(stats);
            }

            Destroy(this);
        }

        void logKill(StatisticManager stats)
        {
            var death = GetComponent<Death>();
            death.AwardKill(stats);
            stats.abilityData.Find(i => i.ability.Name == origin.Name).killed++;
        }
    }
}
