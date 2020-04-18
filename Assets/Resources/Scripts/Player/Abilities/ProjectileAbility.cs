using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Player.Abilities.Buffs;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities
{
    public class ProjectileAbility : Ability
    {
        [SerializeField] private Projectile prototype;


        public override void PlayAbility(Transform user)
        {
            var projectile = Instantiate(prototype, user);
        }
    }
}
