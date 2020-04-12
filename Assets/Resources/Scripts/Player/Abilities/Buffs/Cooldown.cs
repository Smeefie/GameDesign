using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Player.Abilities.Buffs;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities
{
    public class Cooldown : Debuff
    {
        public Ability ability;
        private int CooldownDuration;

        protected override IEnumerator Effect()
        {
            CooldownDuration = ability.baseCooldown; //*GameObject.BaseStats.Cooldownreduction (en make sure niet below een minimum)

            for (int i = CooldownDuration; i > 0; i--)
            {
                yield return new WaitForSeconds(1);
            }

            Destroy(this);
        }
    }
}
