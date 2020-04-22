using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;

namespace Assets.Resources.Scripts.Menu.Unlockables
{
    public class UnlockManager : MonoBehaviour
    {
        [NonSerialized] public Transform player;
        private List<Ability> unlockedAbilities;

        void Start()
        {
            getUnlockedAbilities();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X)) Debug.Log(unlockedAbilitiesToString());
        }

        string unlockedAbilitiesToString()
        {
            var text = "Unlocked abilities : \n";
            unlockedAbilities.ForEach(i=>text += $"|{i.Name}| {i.Description}\n");
            return text;
        }

        public List<Ability> getUnlockedAbilities()
        {

            var stats = player.GetComponent<StatisticManager>();
            List<UnlockableClass> unlockables = gameObject.GetComponentsInChildren<UnlockableClass>().ToList();
            unlockables.ForEach(i =>
            {
                i.CheckCondition(stats);
                i.SetProgression(stats);
            });

            unlockedAbilities = new List<Ability>();
            var unlockedClasses = unlockables.Where(i => !i.isLocked());
            unlockedClasses.ToList().ForEach(i =>
            {
                var abilities = i.playerClass.activeAbilities.Concat(i.playerClass.PassiveAbilities);
                foreach (var ability in abilities)
                {
                    unlockedAbilities.Add(ability);
                }
            });

            return unlockedAbilities;
        }
    }
}