using System.Collections.Generic;
using Assets.Resources.Scripts.Player.Class;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Menu.Unlockables
{
    public class UnlockableClass : Unlockable
    {
        public ClassData playerClass;
        [SerializeField] protected Transform popupWindow;

        void Start()
        {
            gameObject.transform.Find("Name").GetComponent<Text>().text = playerClass.name;
            gameObject.transform.Find("Locked").gameObject.SetActive(Locked);
        }

        public void OnHover()
        {
            Debug.Log(Locked);
            if (Locked) return;
            var popup = Instantiate(popupWindow, this.transform);
            popup.name = PopupwindowName;
            popup.transform.Find("Header").Find("Title").GetComponent<Text>().text = playerClass.name;
            popup.transform.Find("Description").GetComponent<Text>().text = playerClass.description;
        }

        public void OnHoverExit()
        {
            if (Locked) return;
            Destroy(gameObject.transform.Find(PopupwindowName).gameObject);
        }
    }
}
