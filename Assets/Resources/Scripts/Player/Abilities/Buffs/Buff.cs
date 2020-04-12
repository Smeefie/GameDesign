using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities.Buffs
{
    public abstract class Buff : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(Effect());
        }

        protected abstract IEnumerator Effect();
    }
}
