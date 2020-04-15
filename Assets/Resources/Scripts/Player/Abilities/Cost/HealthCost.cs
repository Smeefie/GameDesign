using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBox;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities.Cost
{
    public class HealthCost : Cost
    {
        private int cost;

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
