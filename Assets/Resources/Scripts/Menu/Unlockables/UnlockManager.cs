using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Menu.Unlockables
{
    public class UnlockManager : MonoBehaviour
    {
        [SerializeField] private runtimeStatistics runtimeStatistics;

        void Start()
        {
            List<Unlockable> unlockables = gameObject.GetComponentsInChildren<Unlockable>().ToList();
        }
    }
}