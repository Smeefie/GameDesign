using System.Collections.Generic;
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
            if (Locked) return;
            var popup = Instantiate(popupWindow, this.transform);
            popup.name = PopupwindowName;
            popup.transform.Find("Header").Find("Title").GetComponent<Text>().text = playerClass.name;
            var text = playerClass.description;

            foreach (var ability in playerClass.activeAbilities.Concat(playerClass.PassiveAbilities))
            {
                text += "\n\n " + progression.Find(i=>i.Item1.Name == ability.Name).Item2 + "% " + ability.Name + ": " + ability.Description;
            }
            popup.transform.Find("Description").GetComponent<Text>().text = text;
        }

        public void OnHoverExit()
        {
            if (Locked) return;
            Destroy(gameObject.transform.Find(PopupwindowName).gameObject);
        }

        public override void CheckCondition(runtimeStatistics stats)
        {
            if(playerClass.requirement.isSatisfied(stats)) Unlock();
        }

        public void SetProgression(runtimeStatistics stats)
        {
            progression = new List<(Ability, float)>();
            foreach (var ability in playerClass.activeAbilities.Concat(playerClass.PassiveAbilities))
            {
                progression.Add((ability, ability.unlockRequirement.completionPercentage(stats)));
            }
        }
    }
}
