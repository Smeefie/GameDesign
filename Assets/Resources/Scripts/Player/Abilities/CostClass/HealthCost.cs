using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBox;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities.CostClass
{
    [CreateAssetMenu(fileName = "HealthCost", menuName = "Cost/HealthCost")]
    public class HealthCost : Cost
    {
        [SerializeField] private int cost;

        public HealthCost(int cost)
        {
            this.cost = cost;
        }

        public override bool Pay(GameObject gameObject)
        {
            if (!gameObject.HasComponent<Health>()) return CantAfford();
            var health = gameObject.GetComponent<Health>();
            if (health.CurrentHealth <= cost) return CantAfford();
            health.ReduceHealth(cost);
            return true;
        }
    }
}
