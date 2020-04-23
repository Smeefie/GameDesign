using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Resources.Scripts.Reward
{
    class PlayerDeath : Death
    {
        public override void DeathAction()
        {
            SceneManager.LoadScene(3);
        }
    }
}
