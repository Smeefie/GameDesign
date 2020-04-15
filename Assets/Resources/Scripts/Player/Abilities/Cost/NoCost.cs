using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities.Cost
{
    public class NoCost : Cost
    {
        public override bool Pay(GameObject gameObject)
        {
            return true;
        }
    }
}
