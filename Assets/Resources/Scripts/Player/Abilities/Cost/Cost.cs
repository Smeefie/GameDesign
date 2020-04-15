﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities.Cost
{
    public abstract class Cost
    {
        protected string ErrorMessage = "No error-message was set up";
        public abstract bool Pay(GameObject gameObject);

        protected bool CantAfford()
        {
            Debug.Log(ErrorMessage);
            return false;
        }
    }
}
