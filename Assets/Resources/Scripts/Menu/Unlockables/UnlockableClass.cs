﻿using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Scripts.Player.Class;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Menu.Unlockables
{
    public class UnlockableClass : Unlockable
    {
        public ClassData playerClass;
        [SerializeField] protected Transform popupWindow;

        private List<(Ability, float)> progression;

        void Start()
        {
            gameObject.transform.Find("Name").GetComponent<Text>().text = playerClass.name;
            gameObject.transform.Find("Locked").gameObject.SetActive(Locked);
        }

        public void OnHover()
        {
            if (Locked)
            {
                OpenRequirementText();
            }
            else
            {
                OpenInfoBox();
            }
            
        }

        public void OnHoverExit()
        {
            Destroy(gameObject.transform.Find(PopupwindowName).gameObject);
        }

        public override void CheckCondition(StatisticManager stats)
        {
            if(playerClass.requirement.isSatisfied(stats)) Unlock();
        }

        public void SetProgression(StatisticManager stats)
        {
            progression = new List<(Ability, float)>();
            foreach (var ability in playerClass.activeAbilities.Concat(playerClass.PassiveAbilities))
            {
                progression.Add((ability, ability.unlockRequirement.completionPercentage(stats)));
            }
        }

        void OpenRequirementText()
        {
            var popup = Instantiate(popupWindow, this.transform);
            popup.name = PopupwindowName;
            popup.transform.Find("Header").Find("Title").GetComponent<Text>().text = playerClass.name;
            var text = $"You haven't unlocked {playerClass.name} yet";
            foreach (var requirement in playerClass.requirement.requirements)
            {
                text += "\n\n " + requirement.name + ": " + requirement.description;
            }

            popup.transform.Find("Description").GetComponent<Text>().text = text;
        }

        void OpenInfoBox()
        {
            var popup = Instantiate(popupWindow, this.transform);
            popup.name = PopupwindowName;
            popup.transform.Find("Header").Find("Title").GetComponent<Text>().text = playerClass.name;
            var text = playerClass.description;

            foreach (var ability in playerClass.activeAbilities.Concat(playerClass.PassiveAbilities))
            {
                text += "\n\n " + progression.Find(i => i.Item1.Name == ability.Name).Item2 + "% " + ability.Name + ": " + ability.Description;
            }
            popup.transform.Find("Description").GetComponent<Text>().text = text;
        }
    }
}
