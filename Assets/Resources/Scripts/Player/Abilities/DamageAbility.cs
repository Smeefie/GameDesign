using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Player.Abilities.CostClass;
using Assets.Resources.Scripts.Player.Abilities.Buffs;
using Assets.Resources.Scripts.Player.Abilities.Buffs.ScriptableObjects;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities
{
    [CreateAssetMenu(fileName = "DamageAbility", menuName = "Ability/DamageAbility")]
    public class DamageAbility : Ability
    {
        public DamageType type;
        public DamageCategory category;
        public LayerMask enemyLayers;
        public int DamageDealt;
        public DamageNumbers DoT;

        public float AttackRange;
        public float height;

        public override void PlayAbility(Transform user)
        {
            var stats = user.GetComponent<StatisticManager>();
            var head = user.transform.GetChild(0).gameObject;
            //TODO fix 'getChild(0) solid'

            Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(user.transform.position, new Vector2((user.transform.position.x + AttackRange) * -head.transform.localScale.x, user.transform.position.y + height), enemyLayers);

            foreach (var enemy in hitEnemies)
            {
                var health = enemy.gameObject.GetComponent<Health>();
                Debug.Log("Hit " + enemy.name);
                health.ReduceHealth(DamageDealt);
                var dot = enemy.gameObject.AddComponent<DamageDebuff>();
                dot.Owner = user.gameObject;
                dot.damage = DoT;

                var death = enemy.GetComponent<Death>();
                if (death.isDead) logKill(stats,death);
            }

        }

        void logKill(StatisticManager stats, Death death)
        {
            death.AwardKill(stats);
            stats.abilityData.Find(i => i.ability.Name == Name).killed++;
        }
    }
}
