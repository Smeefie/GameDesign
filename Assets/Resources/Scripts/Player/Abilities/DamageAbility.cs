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
        [SerializeField] private Transform animation;

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
                var anim = Instantiate(animation, enemy.transform);
                anim.transform.position = enemy.transform.position;
                var health = enemy.gameObject.GetComponent<Health>();
                health.ReduceHealth(DamageDealt);
                var dot = enemy.gameObject.AddComponent<DamageDebuff>();
                dot.Owner = user.gameObject;
                dot.damage = DoT;

                stats.abilityData.Find(i => i.ability.Name == Name).hit++;
                var death = enemy.GetComponent<EnemyDeath>();
                if (death.isDead) logKill(stats,death);
            }

        }

        void logKill(StatisticManager stats, EnemyDeath enemyDeath)
        {
            enemyDeath.AwardKill(stats);
            stats.abilityData.Find(i => i.ability.Name == Name).killed++;
        }
    }
}
