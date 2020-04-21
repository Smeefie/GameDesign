using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Player.Abilities
{
    public class AbilitySlot : MonoBehaviour
    {
        public Ability ability;
        public bool Locked = true;
        public bool Equiped = false;
        [SerializeField] private Transform popupWindow;

        private string PopupwindowName = "PopupWindow";

        void Start()
        {
            transform.Find("Name").GetComponent<Text>().text = ability.Name;
            updateEquipedStatus();
            //transform.Find("Icon").GetComponent<Image>().sprite = ability.Icon;
            if (Locked) transform.Find("Icon").GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f);
        }

        void updateEquipedStatus()
        {
            var text = transform.Find("Equiped").GetComponent<Text>();
            if (Equiped) text.text = "Equiped";
            else text.text = "";
        }

        public void Unlock()
        {
            Locked = false;
            transform.Find("Icon").GetComponent<Image>().color = new Color(1,1,1);
        }

        public void OnHover()
        {
            if (Locked)
            {
                OpenProgressText();
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

        void OpenInfoBox()
        {
            var popup = Instantiate(popupWindow, this.transform);
            popup.name = PopupwindowName;
            popup.transform.Find("Header").Find("Title").GetComponent<Text>().text = ability.Name; //todo make ability tostring
            popup.transform.Find("Description").GetComponent<Text>().text = ability.Description;
        }

        void OpenProgressText()
        {
            var stats = gameObject.GetComponentInParent<SkillMenu>().player.GetComponent<StatisticManager>();
            var progression = ability.unlockRequirement.completionPercentage(stats);

            var popup = Instantiate(popupWindow, this.transform);
            popup.name = PopupwindowName;
            popup.transform.Find("Header").Find("Title").GetComponent<Text>().text = ability.Name + " (Locked)";
            var text = progression + "%: " + ability.Description;

            foreach (var requirement in ability.unlockRequirement.requirements)
            {
                text += "\n" + requirement.description;
            }

            popup.transform.Find("Description").GetComponent<Text>().text = ability.Description;
        }

        public void OnClick()
        {
            if (Equiped)
            {
                unequipAbility();
            }
            else
            {
                equipAbility();
            }
        }

        void unequipAbility()
        {
            var abilityManager = GetComponentInParent<SkillMenu>().player.GetComponent<AbilityManager>();
            abilityManager.unequipAbility(ability);

            Equiped = false;
            updateEquipedStatus();
        }

        void equipAbility()
        {
            var error = transform.parent.Find("Error").GetComponent<Text>();
            var abilityManager = GetComponentInParent<SkillMenu>().player.GetComponent<AbilityManager>();

            var abilitiesInUse = abilityManager.getAbilityCount();
            if(abilityManager.getAbilityCount() >= 4) error.text = "Four abilities are currently equiped, unequip one to add another.";
            List<KeyCode> keycodes = new List<KeyCode>()
            {KeyCode.Q, KeyCode.E, KeyCode.R, KeyCode.F};
            List<KeyCode> inUse = abilityManager.getKeycodesInUse().ToList();

            abilityManager.AddAbility(keycodes.Except(inUse).First(), ability);

            Equiped = true;
            updateEquipedStatus();
        }
    }
}
